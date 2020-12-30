﻿using FDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using SlimDX.DirectInput;

namespace TJAPlayer3
{
    internal class CAct特訓モード : CActivity
    {
        public CAct特訓モード()
        {
            base.b活性化してない = true;
        }

        public override void On活性化()
        {
            this.n現在の小節線 = 0;
            this.b特訓PAUSE = false;

            base.On活性化();

            CDTX dTX = TJAPlayer3.DTX;

            var measureCount = 1;
            var bIsInGoGo = false;

            int endtime = 1;
            int bgmlength = 1;

            for (int i = 0; i < dTX.listChip.Count; i++)
            {
                CDTX.CChip pChip = dTX.listChip[i];

                if (pChip.n整数値_内部番号 > measureCount) measureCount = pChip.n整数値_内部番号;
            }

            this.n小節の総数 = measureCount;

            Trace.TraceInformation("TOKKUN: total measures->" + this.n小節の総数);

            length = Math.Max(endtime, bgmlength);

            gogoXList = new List<int>();
            JumpPointList = new List<STJUMPP>();

            for (int i = 0; i < dTX.listChip.Count; i++)
            {
                CDTX.CChip pChip = dTX.listChip[i];

                if (pChip.n整数値_内部番号 > measureCount && pChip.nチャンネル番号 == 0x50) measureCount = pChip.n整数値_内部番号;

                if (pChip.nチャンネル番号 == 0x9E && !bIsInGoGo)
                {
                    bIsInGoGo = true;

                    var current = ((double)(pChip.db発声時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)));
                    var width = 0;
                    if (TJAPlayer3.Tx.Tokkun_ProgressBar != null) width = TJAPlayer3.Tx.Tokkun_ProgressBar.szテクスチャサイズ.Width;

                    this.gogoXList.Add((int)(width * (current / length)));
                }
                if (pChip.nチャンネル番号 == 0x9F && bIsInGoGo)
                {
                    bIsInGoGo = false;
                }
            }

            this.n小節の総数 = measureCount;
        }

        public override void On非活性化()
        {
            length = 1;
            gogoXList = null;
            JumpPointList = null;
            base.On非活性化();
        }

        public override void OnManagedリソースの作成()
        {
            if (!base.b活性化してない)
            {
                if (TJAPlayer3.Tx.Tokkun_Background_Up != null) this.ct背景スクロールタイマー = new CCounter(1, TJAPlayer3.Tx.Tokkun_Background_Up.szテクスチャサイズ.Width, 16, TJAPlayer3.Timer);
                base.OnManagedリソースの作成();
            }
        }

        public override void OnManagedリソースの解放()
        {
            if (!base.b活性化してない)
            {
                this.ctスクロールカウンター = null;
                this.ct背景スクロールタイマー = null;
                base.OnManagedリソースの解放();
            }
        }

        public override int On進行描画()
        {
            if (!base.b活性化してない)
            {
                if (base.b初めての進行描画)
                {
                    base.b初めての進行描画 = false;
                }

                TJAPlayer3.act文字コンソール.tPrint(0, 0, C文字コンソール.Eフォント種別.白, "TRAINING MODE (BETA)");

                TJAPlayer3.act文字コンソール.tPrint(256, 360, C文字コンソール.Eフォント種別.白, TJAPlayer3.stage演奏ドラム画面.actPlayInfo.NowMeasure[0] + "/" + this.n小節の総数);

                if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)Key.Space))
                {
                    if (this.b特訓PAUSE)
                    {
                        TJAPlayer3.Skin.sound特訓再生音.t再生する();
                        this.t演奏を再開する();
                    }
                    else
                    {
                        TJAPlayer3.Skin.sound特訓停止音.t再生する();
                        this.t演奏を停止する();
                    }
                }
                if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)Key.LeftArrow) || TJAPlayer3.Pad.b押されたDGB(Eパッド.LBlue))
                {
                    if (this.b特訓PAUSE)
                    {
                        if (this.n現在の小節線 > 1)
                        {
                            this.n現在の小節線--;
                            TJAPlayer3.stage演奏ドラム画面.actPlayInfo.NowMeasure[0] = this.n現在の小節線;

                            this.t譜面の表示位置を合わせる(true);
                            TJAPlayer3.Skin.sound特訓スクロール音.t再生する();
                        }
                    }
                }
                if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)Key.RightArrow) || TJAPlayer3.Pad.b押されたDGB(Eパッド.RBlue))
                {
                    if (this.b特訓PAUSE)
                    {
                        if (this.n現在の小節線 < this.n小節の総数)
                        {
                            this.n現在の小節線++;
                            TJAPlayer3.stage演奏ドラム画面.actPlayInfo.NowMeasure[0] = this.n現在の小節線;

                            this.t譜面の表示位置を合わせる(true);
                            TJAPlayer3.Skin.sound特訓スクロール音.t再生する();
                        }
                    }
                }

                if (this.bスクロール中)
                {
                    CSound管理.rc演奏用タイマ.n現在時刻ms = easing.EaseOut(this.ctスクロールカウンター, (int)this.nスクロール前ms, (int)this.nスクロール後ms, Easing.CalcType.Circular);

                    this.ctスクロールカウンター.t進行();

                    if ((int)CSound管理.rc演奏用タイマ.n現在時刻ms == (int)this.nスクロール後ms)
                    {
                        this.bスクロール中 = false;
                        CSound管理.rc演奏用タイマ.n現在時刻ms = this.nスクロール後ms;
                    }
                }

                if (!this.b特訓PAUSE && this.n現在の小節線 < TJAPlayer3.stage演奏ドラム画面.actPlayInfo.NowMeasure[0]) this.n現在の小節線 = TJAPlayer3.stage演奏ドラム画面.actPlayInfo.NowMeasure[0];

            }
            return base.On進行描画();
        }
        public int On進行描画_背景()
        {
            if (this.ct背景スクロールタイマー != null)
            {
                this.ct背景スクロールタイマー.t進行Loop();

                double TexSize = 1280 / TJAPlayer3.Tx.Tokkun_Background_Up.szテクスチャサイズ.Width;
                // 1280をテクスチャサイズで割ったものを切り上げて、プラス+1足す。
                int ForLoop = (int)Math.Ceiling(TexSize) + 1;
                TJAPlayer3.Tx.Tokkun_Background_Up.t2D描画(TJAPlayer3.app.Device, 0 - this.ct背景スクロールタイマー.n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[0]);
                for (int l = 1; l < ForLoop + 1; l++)
                {
                    TJAPlayer3.Tx.Tokkun_Background_Up.t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Tokkun_Background_Up.szテクスチャサイズ.Width) - this.ct背景スクロールタイマー.n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[0]);
                }
            }

            if (TJAPlayer3.Tx.Tokkun_DownBG != null) TJAPlayer3.Tx.Tokkun_DownBG.t2D描画(TJAPlayer3.app.Device, 0, 360);
            if (TJAPlayer3.Tx.Tokkun_BigTaiko != null) TJAPlayer3.Tx.Tokkun_BigTaiko.t2D描画(TJAPlayer3.app.Device, 334, 400);

            return base.On進行描画();
        }
        public void On進行描画_小節_速度()
        {
            if (TJAPlayer3.Tx.Tokkun_Speed_Measure != null)
                TJAPlayer3.Tx.Tokkun_Speed_Measure.t2D描画(TJAPlayer3.app.Device, 0, 360);
            var maxMeasureStr = this.n小節の総数.ToString();
            var measureStr = TJAPlayer3.stage演奏ドラム画面.actPlayInfo.NowMeasure[0].ToString();
            if (TJAPlayer3.Tx.Tokkun_SmallNumber != null)
            {
                var x = TJAPlayer3.Skin.Game_Training_MaxMeasureCount_XY[0];
                foreach (char c in maxMeasureStr)
                {
                    var currentNum = int.Parse(c.ToString());
                    TJAPlayer3.Tx.Tokkun_SmallNumber.t2D描画(TJAPlayer3.app.Device, x, TJAPlayer3.Skin.Game_Training_MaxMeasureCount_XY[1], new Rectangle(TJAPlayer3.Skin.Game_Training_SmallNumber_Width * currentNum, 0, TJAPlayer3.Skin.Game_Training_SmallNumber_Width, TJAPlayer3.Tx.Tokkun_SmallNumber.szテクスチャサイズ.Height));
                    x += TJAPlayer3.Skin.Game_Training_SmallNumber_Width - 2;
                }
            }

            var subtractVal = (TJAPlayer3.Skin.Game_Training_BigNumber_Width - 2) * (measureStr.Length - 1);

            if (TJAPlayer3.Tx.Tokkun_BigNumber != null)
            {
                var x = TJAPlayer3.Skin.Game_Training_CurrentMeasureCount_XY[0];
                foreach (char c in measureStr)
                {
                    var currentNum = int.Parse(c.ToString());
                    TJAPlayer3.Tx.Tokkun_BigNumber.t2D描画(TJAPlayer3.app.Device, x - subtractVal, TJAPlayer3.Skin.Game_Training_CurrentMeasureCount_XY[1], new Rectangle(TJAPlayer3.Skin.Game_Training_BigNumber_Width * currentNum, 0, TJAPlayer3.Skin.Game_Training_BigNumber_Width, TJAPlayer3.Tx.Tokkun_BigNumber.szテクスチャサイズ.Height));
                    x += TJAPlayer3.Skin.Game_Training_BigNumber_Width - 2;
                }

                var PlaySpdtmp = TJAPlayer3.ConfigIni.n演奏速度 / 20.0d * 10.0d;
                PlaySpdtmp = Math.Round(PlaySpdtmp, MidpointRounding.AwayFromZero);

                var playSpd = PlaySpdtmp / 10.0d;
                var playSpdI = playSpd - (int)playSpd;
                var playSpdStr = Decimal.Round((decimal)playSpdI, 1, MidpointRounding.AwayFromZero).ToString();
                var decimalStr = (playSpdStr == "0") ? "0" : playSpdStr[2].ToString();

                TJAPlayer3.Tx.Tokkun_BigNumber.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Training_SpeedDisplay_XY[0], TJAPlayer3.Skin.Game_Training_SpeedDisplay_XY[1], new Rectangle(TJAPlayer3.Skin.Game_Training_BigNumber_Width * int.Parse(decimalStr), 0, TJAPlayer3.Skin.Game_Training_BigNumber_Width, TJAPlayer3.Tx.Tokkun_BigNumber.szテクスチャサイズ.Height));

                x = TJAPlayer3.Skin.Game_Training_SpeedDisplay_XY[0] - 25;

                subtractVal = TJAPlayer3.Skin.Game_Training_BigNumber_Width * (((int)playSpd).ToString().Length - 1);

                foreach (char c in ((int)playSpd).ToString())
                {
                    var currentNum = int.Parse(c.ToString());
                    TJAPlayer3.Tx.Tokkun_BigNumber.t2D描画(TJAPlayer3.app.Device, x - subtractVal, TJAPlayer3.Skin.Game_Training_SpeedDisplay_XY[1], new Rectangle(TJAPlayer3.Skin.Game_Training_BigNumber_Width * currentNum, 0, TJAPlayer3.Skin.Game_Training_BigNumber_Width, TJAPlayer3.Tx.Tokkun_BigNumber.szテクスチャサイズ.Height));
                    x += TJAPlayer3.Skin.Game_Training_BigNumber_Width - 2;
                }
            }
        }

        public void t演奏を停止する()
        {
            CDTX dTX = TJAPlayer3.DTX;

            TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t判定枠Reset();

            this.nスクロール後ms = CSound管理.rc演奏用タイマ.n現在時刻ms;

            TJAPlayer3.stage演奏ドラム画面.On活性化();
            CSound管理.rc演奏用タイマ.t一時停止();

            for (int i = 0; i < dTX.listChip.Count; i++)
            {
                CDTX.CChip pChip = dTX.listChip[i];
                pChip.bHit = false;
                if (dTX.listChip[i].nチャンネル番号 != 0x50)
                {
                    pChip.bShow = true;
                    pChip.b可視 = true;
                }
            }

            TJAPlayer3.DTX.t全チップの再生一時停止();
            TJAPlayer3.stage演奏ドラム画面.bPAUSE = true;
            TJAPlayer3.stage演奏ドラム画面.actPlayInfo.NowMeasure[0] = this.n現在の小節線;
            this.b特訓PAUSE = true;

            this.t譜面の表示位置を合わせる(false);
        }

        public void t演奏を再開する()
        {
            CDTX dTX = TJAPlayer3.DTX;

            TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t判定枠Reset();

            this.bスクロール中 = false;
            CSound管理.rc演奏用タイマ.n現在時刻ms = this.nスクロール後ms;

            int n演奏開始Chip = TJAPlayer3.stage演奏ドラム画面.n現在のトップChip;
            int finalStartBar;

            finalStartBar = this.n現在の小節線 - 2;
            if (finalStartBar < 0) finalStartBar = 0;

            TJAPlayer3.stage演奏ドラム画面.t演奏位置の変更(finalStartBar, 0);


            int n少し戻ってから演奏開始Chip = TJAPlayer3.stage演奏ドラム画面.n現在のトップChip;

            TJAPlayer3.stage演奏ドラム画面.actPlayInfo.NowMeasure[0] = 0;
            TJAPlayer3.stage演奏ドラム画面.t数値の初期化(true, true);
            TJAPlayer3.stage演奏ドラム画面.On活性化();

            for (int i = 0; i < dTX.listChip.Count; i++)
            {
                if (i < n演奏開始Chip && (dTX.listChip[i].nチャンネル番号 > 0x10 && dTX.listChip[i].nチャンネル番号 < 0x20)) //2020.07.08 ノーツだけ消す。 null参照回避のために順番変更
                {
                    dTX.listChip[i].bHit = true;
                    dTX.listChip[i].IsHitted = true;
                    dTX.listChip[i].b可視 = false;
                    dTX.listChip[i].bShow = false;
                }
                if (i < n少し戻ってから演奏開始Chip && dTX.listChip[i].nチャンネル番号 == 0x01)
                {
                    dTX.listChip[i].bHit = true;
                    dTX.listChip[i].IsHitted = true;
                    dTX.listChip[i].b可視 = false;
                    dTX.listChip[i].bShow = false;
                }
                if (dTX.listChip[i].nチャンネル番号 == 0x50 && dTX.listChip[i].n整数値_内部番号 < finalStartBar)
                {
                    dTX.listChip[i].bHit = true;
                    dTX.listChip[i].IsHitted = true;
                }

            }

            for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
            {
                TJAPlayer3.stage演奏ドラム画面.chip現在処理中の連打チップ[i] = null;
            }

            this.b特訓PAUSE = false;
        }

        public void t譜面の表示位置を合わせる(bool doScroll)
        {
            this.nスクロール前ms = CSound管理.rc演奏用タイマ.n現在時刻ms;

            CDTX dTX = TJAPlayer3.DTX;

            bool bSuccessSeek = false;
            for (int i = 0; i < dTX.listChip.Count; i++)
            {
                CDTX.CChip pChip = dTX.listChip[i];

                if (pChip.n発声位置 < 384 * (n現在の小節線))
                {
                    continue;
                }
                else
                {
                    bSuccessSeek = true;
                    TJAPlayer3.stage演奏ドラム画面.n現在のトップChip = i;
                    break;
                }
            }
            if (!bSuccessSeek)
            {
                TJAPlayer3.stage演奏ドラム画面.n現在のトップChip = 0;
            }

            if (doScroll)
            {
                this.nスクロール後ms = dTX.listChip[TJAPlayer3.stage演奏ドラム画面.n現在のトップChip].n発声時刻ms;
                this.bスクロール中 = true;

                this.ctスクロールカウンター = new CCounter(0, 350, 1, TJAPlayer3.Timer);
            }
            else
            {
                CSound管理.rc演奏用タイマ.n現在時刻ms = dTX.listChip[TJAPlayer3.stage演奏ドラム画面.n現在のトップChip].n発声時刻ms;
            }
        }

        public int n現在の小節線;
        public int n小節の総数;

        #region [private]
        private long nスクロール前ms;
        private long nスクロール後ms;

        private bool b特訓PAUSE;
        private bool bスクロール中;

        private CCounter ctスクロールカウンター;
        private CCounter ct背景スクロールタイマー;

        private CCounter スクロールカウンター;
        private Easing easing = new Easing();
        private long length = 1;

        private List<int> gogoXList;
        private List<STJUMPP> JumpPointList;
        private long[] LBlue = new long[] { 0, 0, 0, 0, 0 };
        private long[] RBlue = new long[] { 0, 0, 0, 0, 0 };

        private struct STJUMPP
        {
            public long Time;
            public int Measure;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time">今の時間</param>
        /// <param name="begin">最初の値</param>
        /// <param name="change">最終の値-最初の値</param>
        /// <param name="duration">全体の時間</param>
        /// <returns></returns>
        private int EasingCircular(int time, int begin, int change, int duration)
        {
            double t = time, b = begin, c = change, d = duration;

            t = t / d * 2;
            if (t < 1)
                return (int)(-c / 2 * (Math.Sqrt(1 - t * t) - 1) + b);
            else
            {
                t = t - 2;
                return (int)(c / 2 * (Math.Sqrt(1 - t * t) + 1) + b);
            }
        }
        #endregion
    }
}