using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using FDK;

namespace TJAPlayer3
{
    internal class CAct演奏Drums演奏終了演出 : CActivity
    {
        /// <summary>
        /// 課題
        /// _クリア失敗 →素材不足(確保はできる。切り出しと加工をしてないだけ。)
        /// _
        /// </summary>
        public CAct演奏Drums演奏終了演出()
        {
            base.b活性化してない = true;
        }

        public void Start()
        {
            this.ct進行メイン = new CCounter(0, 500, 1000 / 60, TJAPlayer3.Timer);
            // モードの決定。クリア失敗・フルコンボも事前に作っとく。
            if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] == (int)Difficulty.Dan)
            {
                // 段位認定モード。
                if (!TJAPlayer3.stage演奏ドラム画面.actDan.GetFailedAllChallenges())
                {
                    // 段位認定モード、クリア成功
                    this.Mode[0] = EndMode.StageCleared;
                }
                else
                {
                    // 段位認定モード、クリア失敗
                    this.Mode[0] = EndMode.StageFailed;
                }
            }
            else
            {
                // 通常のモード。
                // ここでフルコンボフラグをチェックするが現時点ではない。
                // 今の段階では魂ゲージ80%以上でチェック。
                for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
                {
                    if (TJAPlayer3.stage演奏ドラム画面.actGauge.db現在のゲージ値[i] >= 80)
                    {
                        if(TJAPlayer3.stage演奏ドラム画面.nヒット数_Auto含む.Drums.Miss == 0)
                        {
                            if(TJAPlayer3.stage演奏ドラム画面.nヒット数_Auto含む.Drums.Great == 0)
                            {
                                this.Mode[i] = EndMode.StageDondaFullCombo;
                            }
                            else
                            {
                                this.Mode[i] = EndMode.StageFullCombo;
                            }
                        }
                        else
                        {
                            this.Mode[i] = EndMode.StageCleared;
                        }
                    }
                    else
                    {
                        this.Mode[i] = EndMode.StageFailed;
                    }
                }
            }
        }

        public override void On活性化()
        {
            this.bリザルトボイス再生済み = false;
            this.Mode = new EndMode[2];
            base.On活性化();
        }

        public override void On非活性化()
        {
            this.ct進行メイン = null;
            base.On非活性化();
        }

        public override void OnManagedリソースの作成()
        {
            this.b再生済み = false;
            this.soundClear = TJAPlayer3.Sound管理.tサウンドを生成する(CSkin.Path(@"Sounds\Clear.ogg"), ESoundGroup.SoundEffect);
            base.OnManagedリソースの作成();
        }

        public override void OnManagedリソースの解放()
        {
            if (this.soundClear != null)
                this.soundClear.t解放する();
            base.OnManagedリソースの解放();
        }

        public override int On進行描画()
        {
            if (base.b初めての進行描画)
            {
                base.b初めての進行描画 = false;
            }
            if (this.ct進行メイン != null && (TJAPlayer3.stage演奏ドラム画面.eフェーズID == CStage.Eフェーズ.演奏_演奏終了演出 || TJAPlayer3.stage演奏ドラム画面.eフェーズID == CStage.Eフェーズ.演奏_STAGE_CLEAR_フェードアウト))
            {
                this.ct進行メイン.t進行();

                for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
                {
                    switch (this.Mode[i])
                    {
                        case EndMode.StageFailed:
                            break;
                        case EndMode.StageCleared:
                            int[] y = new int[] { 300, 386 };
                            for (int j = 0; j < TJAPlayer3.ConfigIni.nPlayerCount; j++)
                            {
                                if (this.soundClear != null && !this.b再生済み)
                                {
                                    this.soundClear.t再生を開始する();
                                    this.b再生済み = true;
                                }
                            }
                            if (TJAPlayer3.Tx.End_Clear_Text != null)
                            {
                                #region[ 文字 ]

                                float[] f文字拡大率 = new float[] { 1.04f, 1.11f, 1.15f, 1.19f, 1.23f, 1.26f, 1.30f, 1.31f, 1.32f, 1.32f, 1.32f, 1.30f, 1.30f, 1.26f, 1.25f, 1.19f, 1.15f, 1.11f, 1.05f, 1.0f };
                                int[] n透明度 = new int[] { 43, 85, 128, 170, 213, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255 };

                                for(int j = 0; j < 5; j++)
                                {
                                    if (this.ct進行メイン.n現在の値 >= 25 + j * 3)
                                    {
                                        if (this.ct進行メイン.n現在の値 <= 44 + j * 3)
                                        {
                                            TJAPlayer3.Tx.End_Clear_Text[0].vc拡大縮小倍率.Y = f文字拡大率[this.ct進行メイン.n現在の値 - (25 + j * 3)];
                                            TJAPlayer3.Tx.End_Clear_Text[0].Opacity = n透明度[this.ct進行メイン.n現在の値 - (25 + j * 3)];
                                            TJAPlayer3.Tx.End_Clear_Text[0].t2D拡大率考慮下基準描画(TJAPlayer3.app.Device, 634 + (j < 3 ? j * 58 : 2 * 58 + (j - 2) * 65), y[i], new Rectangle(90 * j, 0, 90, 90));
                                        }
                                        else
                                        {
                                            if (this.ct進行メイン.n現在の値 <= 78)
                                            {
                                                TJAPlayer3.Tx.End_Clear_Text[0].vc拡大縮小倍率.Y = 1.0f;
                                                TJAPlayer3.Tx.End_Clear_Text[0].Opacity = 255;
                                                TJAPlayer3.Tx.End_Clear_Text[0].t2D拡大率考慮下基準描画(TJAPlayer3.app.Device, 634 + (j < 3 ? j * 58 : 2 * 58 + (j - 2) * 65), y[i], new Rectangle(90 * j, 0, 90, 90));
                                            }
                                            else
                                            {
                                                TJAPlayer3.Tx.End_Clear_Text[1].Opacity = 255;
                                                TJAPlayer3.Tx.End_Clear_Text[1].t2D描画(TJAPlayer3.app.Device, 641, y[i] - 85, new Rectangle(0, 0, 334, 84));
                                            }
                                        }
                                    }

                                    if (this.ct進行メイン.n現在の値 >= 67)
                                    {
                                        if (this.ct進行メイン.n現在の値 <= 78)
                                        {
                                            TJAPlayer3.Tx.End_Clear_Text[0].Opacity = (int)((this.ct進行メイン.n現在の値 - 67) * 23.18181f);
                                            TJAPlayer3.Tx.End_Clear_Text[0].t2D拡大率考慮下基準描画(TJAPlayer3.app.Device, 634 + (j < 3 ? j * 58 : 2 * 58 + (j - 2) * 65), y[i], new Rectangle(90 * j, 90, 90, 90));
                                        }
                                        else if (this.ct進行メイン.n現在の値 <= 89)
                                        {
                                            TJAPlayer3.Tx.End_Clear_Text[0].Opacity = 0;
                                            TJAPlayer3.Tx.End_Clear_Text[1].Opacity = (int)(255 - ((this.ct進行メイン.n現在の値 - 78) * 23.18181f));
                                            TJAPlayer3.Tx.End_Clear_Text[1].t2D描画(TJAPlayer3.app.Device, 641, y[i] - 85, new Rectangle(0, 84, 334, 84));
                                        }
                                    }
                                }
                                #endregion

                                #region[ バチお ]

                                if (this.ct進行メイン.n現在の値 <= 13)   //35
                                {
                                    if (TJAPlayer3.Tx.End_Clear_Chara != null)
                                    {
                                        TJAPlayer3.Tx.End_Clear_Chara.Opacity = (int)(this.ct進行メイン.n現在の値 * 19.7f);
                                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 694, 178, new RectangleF(180, 0, 180, 180));
                                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 727, 178, new RectangleF(180, 180, 180, 180));
                                    }
                                }
                                else if(this.ct進行メイン.n現在の値 <= 48)
                                {
                                    if (TJAPlayer3.Tx.End_Clear_Chara != null)
                                    {
                                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - (float)Math.Sin((this.ct進行メイン.n現在の値 - 13) * 2.57142 * (Math.PI / 180)) * 218, y[i] - 122, new RectangleF(0, 0, 180, 180));
                                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + (float)Math.Sin((this.ct進行メイン.n現在の値 - 13) * 2.57142 * (Math.PI / 180)) * 218, y[i] - 122, new RectangleF(0, 180, 180, 180));
                                    }
                                }
                                else if(this.ct進行メイン.n現在の値 <= 52)
                                {
                                    if (TJAPlayer3.Tx.End_Clear_Chara != null)
                                    {
                                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - 218, y[i] - 122, new RectangleF(180, 0, 180, 180));
                                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + 218, y[i] - 122, new RectangleF(180, 180, 180, 180));
                                    }
                                }
                                else if(this.ct進行メイン.n現在の値 <= 55)
                                {
                                    if (TJAPlayer3.Tx.End_Clear_Chara != null)
                                    {
                                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - 218, 178, new RectangleF(360, 0, 180, 180));
                                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + 218, 178, new RectangleF(360, 180, 180, 180));
                                    }
                                }
                                else if(this.ct進行メイン.n現在の値 <= 58)
                                {
                                    if (TJAPlayer3.Tx.End_Clear_Chara != null)
                                    {
                                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - 218, 178, new RectangleF(540, 0, 180, 180));
                                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + 218, 178, new RectangleF(540, 0, 180, 180));
                                    }
                                }
                                else if (this.ct進行メイン.n現在の値 <= 62)
                                {
                                    if (TJAPlayer3.Tx.End_Clear_Chara != null)
                                    {
                                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - 218, 178, new RectangleF(720, 0, 180, 180));
                                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + 218, 178, new RectangleF(720, 180, 180, 180));
                                    }
                                }
                                else
                                {
                                    if (TJAPlayer3.Tx.End_Clear_Chara != null)
                                    {
                                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - 218, 178, new RectangleF(900, 0, 180, 180));
                                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + 218, 178, new RectangleF(900, 180, 180, 180));
                                    }
                                }

                                #endregion

                                #region [ 星アニメ ]

                                if(this.ct進行メイン.n現在の値 >= 123)
                                {
                                    if (this.ct進行Loop == null) ct進行Loop = new CCounter(0, 93, 1000 / 60, TJAPlayer3.Timer);

                                    ct進行Loop.t進行Loop();

                                    StarDraw(683, 209, ct進行Loop.n現在の値, 0, 12);
                                    StarDraw(683, 209, ct進行Loop.n現在の値 - 12);

                                    StarDraw(803, 208, ct進行Loop.n現在の値, 10);
                                    StarDraw(803, 208, ct進行Loop.n現在の値 - 12, 0, 8);

                                    StarDraw(926, 208, ct進行Loop.n現在の値 - 6, 14);
                                    StarDraw(926, 208, ct進行Loop.n現在の値 - 12, 0, 14);

                                    StarDraw(644, 287, ct進行Loop.n現在の値 - 26, 18);
                                    StarDraw(644, 287, ct進行Loop.n現在の値 - 30, 0, 14);

                                    StarDraw(726, 305, ct進行Loop.n現在の値 - 15, 7);
                                    StarDraw(726, 305, ct進行Loop.n現在の値 - 30, 0, 4);

                                    StarDraw(874, 305, ct進行Loop.n現在の値 - 30);

                                    StarDraw(962, 291, ct進行Loop.n現在の値 - 21, 13);
                                    StarDraw(962, 291, ct進行Loop.n現在の値 - 30, 0, 9);
                                }

                                #endregion
                            }
                            break;
                        case EndMode.StageFullCombo:
                            break;
                        case EndMode.StageDondaFullCombo:
                            break;
                        default:
                            break;
                    }

                }



                if (this.ct進行メイン.b終了値に達した)
                {
                    if (!this.bリザルトボイス再生済み)
                    {
                        this.bリザルトボイス再生済み = true;
                    }
                    return 1;
                }
            }

            return 0;
        }

        #region[ private ]
        //-----------------
        bool b再生済み;
        bool bリザルトボイス再生済み;
        CCounter ct進行メイン;
        CCounter ct進行Loop;
        CSound soundClear;
        EndMode[] Mode;
        enum EndMode
        {
            StageFailed,
            StageCleared,
            StageFullCombo,
            StageDondaFullCombo
        }

        void StarDraw(int x, int y, int count, int starttime = 0, int Endtime = 20)
        {
            if (count >= 0 && count <= Endtime)
            {
                count += starttime;

                if (count <= 11)
                {
                    TJAPlayer3.Tx.End_Star.vc拡大縮小倍率.X = count * 0.09f;
                    TJAPlayer3.Tx.End_Star.vc拡大縮小倍率.Y = count * 0.09f;
                    TJAPlayer3.Tx.End_Star.Opacity = 255;
                    TJAPlayer3.Tx.End_Star.t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x, y);
                }
                else if (count <= 20)
                {
                    TJAPlayer3.Tx.End_Star.vc拡大縮小倍率.X = 1.0f;
                    TJAPlayer3.Tx.End_Star.vc拡大縮小倍率.Y = 1.0f;
                    TJAPlayer3.Tx.End_Star.Opacity = (int)(255 - (255.0f / 9.0f) * (count - 11));
                    TJAPlayer3.Tx.End_Star.t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x, y);
                }
            }
        }

        //-----------------
        #endregion
    }
}
