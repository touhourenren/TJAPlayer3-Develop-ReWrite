using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Drawing.Text;

using SlimDX;
using FDK;

namespace TJAPlayer3
{
    /// <summary>
    /// 難易度選択画面。
    /// この難易度選択画面はAC7～AC14のような方式であり、WiiまたはAC15移行の方式とは異なる。
    /// </summary>
	internal class CActSelect難易度選択画面 : CActivity
	{
		// プロパティ

        public bool bIsDifficltSelect;

		// コンストラクタ

        public CActSelect難易度選択画面()
        {
            for(int i = 0; i < 10; i++)
            {
                st小文字位置[i].ptX = i * 18;
                st小文字位置[i].ch = i.ToString().ToCharArray()[0];
            }
            base.b活性化してない = true;
		}

        public void t次に移動()
        {
            if (n現在の選択行 + 1 <= 5)
            {
                ctBarAnime.t開始(0, 180, 1, TJAPlayer3.Timer);
                n現在の選択行++;
            }
            else
            {
                nスイッチカウント++;
                if(nスイッチカウント >= 10)
                {
                    if (n現在の選択行 == 5)
                    {
                        if(TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[4] >= 0)
                        {
                            n現在の選択行 = 6;
                            b裏譜面 = true;
                        }
                    }
                    else if (n現在の選択行 == 6)
                    {
                        b裏譜面 = false;
                        n現在の選択行 = 5;
                    }

                    nスイッチカウント = 0;
                }
            }
        }

		public void t前に移動()
		{
            if(n現在の選択行 - 1 >= 0)
            {
                ctBarAnime.t開始(0, 180, 1, TJAPlayer3.Timer);
                nスイッチカウント = 0;
                if(n現在の選択行 == 6)
                    n現在の選択行 -= 2;
                else
                    n現在の選択行--;
            }
		}

		public void t選択画面初期化()
        {
            if (!string.IsNullOrEmpty(TJAPlayer3.ConfigIni.FontName))
            {
                this.pfTitle = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 28);
                this.pfSubTitle = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 16);
            }
            else
            {
                this.pfTitle = new CPrivateFastFont(new FontFamily("MS UI Gothic"), 28);
                this.pfSubTitle = new CPrivateFastFont(new FontFamily("MS UI Gothic"), 16);
            }

            this.txTitle = TJAPlayer3.tテクスチャの生成(pfTitle.DrawPrivateFont(TJAPlayer3.stage選曲.r現在選択中の曲.strタイトル, Color.White, Color.Black ));
            this.txSubTitle = TJAPlayer3.tテクスチャの生成(pfSubTitle.DrawPrivateFont(TJAPlayer3.stage選曲.r現在選択中の曲.strサブタイトル, Color.White, Color.Black));

            this.n現在の選択行 = 0;
            this.bSelect = false;
            this.b裏譜面 = false;

            this.b初めての進行描画 = true;
		}

		// CActivity 実装

		public override void On活性化()
		{
			if( this.b活性化してる )
				return;

            ctBarAnime = new CCounter();

            base.On活性化();
		}
		public override void On非活性化()
		{
			if( this.b活性化してない )
				return;

            ctBarAnime = null;

            base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if( this.b活性化してない )
				return;

            this.soundSelectAnnounce = TJAPlayer3.Sound管理.tサウンドを生成する( CSkin.Path( @"Sounds\DiffSelect.ogg" ), ESoundGroup.SoundEffect );

			base.OnManagedリソースの作成();
		}
		public override void OnManagedリソースの解放()
		{
			if( this.b活性化してない )
				return;

            TJAPlayer3.t安全にDisposeする( ref this.soundSelectAnnounce );

			base.OnManagedリソースの解放();
		}
        public override int On進行描画()
        {
            if (this.b活性化してない)
                return 0;

            #region [ 初めての進行描画 ]
            //-----------------
            if (this.b初めての進行描画)
            {
                ctBarAnimeIn = new CCounter(0, 170, 4, TJAPlayer3.Timer);
                this.soundSelectAnnounce?.tサウンドを再生する();
                base.b初めての進行描画 = false;
            }
            //-----------------
            #endregion

            ctBarAnimeIn.t進行();
            ctBarAnime.t進行();

            #region [ キー入力 ]

            if (this.ctBarAnimeIn.b終了値に達した && !bSelect)
            {
                if (TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.RBlue))
                {
                    TJAPlayer3.Skin.sound変更音.t再生する();
                    this.t次に移動();
                }
                else if (TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.LBlue))
                {
                    TJAPlayer3.Skin.sound変更音.t再生する();
                    this.t前に移動();
                }
                else if (TJAPlayer3.Pad.b押されたDGB(Eパッド.Decide) || TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.LRed) || TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.RRed) ||
                     (TJAPlayer3.ConfigIni.bEnterがキー割り当てのどこにも使用されていない && TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDX.DirectInput.Key.Return)))
                {
                    if (n現在の選択行 == 0)
                    {
                        TJAPlayer3.Skin.sound決定音.t再生する();
                        TJAPlayer3.stage選曲.act曲リスト.ctBarOpen.t開始(100, 260, 2, TJAPlayer3.Timer);
                        this.bIsDifficltSelect = false;
                    }
                    else if (n現在の選択行 == 1)
                    {
                        TJAPlayer3.Skin.sound決定音.t再生する();
                    }
                    else
                    {
                        if(TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[n現在の選択行 - 2] > 0)
                        {
                            TJAPlayer3.stage選曲.ctDonchan_Jump.t開始(0, TJAPlayer3.Tx.SongSelect_Donchan_Jump.Length - 1, 1000 / 45, TJAPlayer3.Timer);
                            this.bSelect = true;
                            TJAPlayer3.Skin.sound曲決定音.t再生する();
                            TJAPlayer3.stage選曲.t曲を選択する(n現在の選択行 - 2);
                        }
                    }
                }
            }

            #endregion

            #region [ 画像描画 ]

            TJAPlayer3.Tx.Difficulty_Back[nStrジャンルtoNum(TJAPlayer3.stage選曲.r現在選択中の曲.strジャンル)].Opacity =
                (TJAPlayer3.stage選曲.act曲リスト.ctDifficultyIn.n現在の値 - 1255);
            TJAPlayer3.Tx.Difficulty_Bar.Opacity = (TJAPlayer3.stage選曲.act曲リスト.ctDifficultyIn.n現在の値 - 1255);
            TJAPlayer3.Tx.Difficulty_Number.Opacity = (TJAPlayer3.stage選曲.act曲リスト.ctDifficultyIn.n現在の値 - 1255);

            TJAPlayer3.Tx.Difficulty_Back[nStrジャンルtoNum(TJAPlayer3.stage選曲.r現在選択中の曲.strジャンル)].t2D中心基準描画(TJAPlayer3.app.Device, 640, 290);

            TJAPlayer3.Tx.Difficulty_Select_Bar.Opacity = (int)(ctBarAnimeIn.n現在の値 >= 80 ? (ctBarAnimeIn.n現在の値 - 80) * 2.84f : 0);
            TJAPlayer3.Tx.Difficulty_Select_Bar.t2D描画(TJAPlayer3.app.Device, (float)this.BarX[n現在の選択行], 242, new RectangleF(0, (n現在の選択行 >= 2 ? 114 : 387), 259, 275 - (n現在の選択行 >= 2 ? 0 : 164)));

            TJAPlayer3.Tx.Difficulty_Bar.color4 = new Color4(1.0f, 1.0f, 1.0f);
            TJAPlayer3.Tx.Difficulty_Bar.t2D描画(TJAPlayer3.app.Device, 255, 270, new RectangleF(0, 0, 171, 236));    //閉じる、演奏オプション


            for (int i = 0; i < 3; i++)
            {
                if(TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[i] > 0)
                    TJAPlayer3.Tx.Difficulty_Bar.color4 = new Color4(1.0f, 1.0f, 1.0f);
                else
                    TJAPlayer3.Tx.Difficulty_Bar.color4 = new Color4(0.5f, 0.5f, 0.5f);

                TJAPlayer3.Tx.Difficulty_Bar.t2D描画(TJAPlayer3.app.Device, 255 + 171 + 143 * i, 270, new RectangleF(171 + 143 * i, 0, 143, 236));    //閉じる～難しいまで

                if (TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[i] > 0)
                    t小文字表示(TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[i].ToString(), 498 + i * 144, 434.5f);

                for(int g = 0; g < TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[i]; g++)
                {
                    if (TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[i] > 0)
                    {
                        TJAPlayer3.Tx.Difficulty_Star.t2D描画(TJAPlayer3.app.Device, 444 + i * 143 + g * 10, 459);
                    }
                }
            }

            if (b裏譜面)
            {
                if (TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[4] > 0)
                    TJAPlayer3.Tx.Difficulty_Bar.color4 = new Color4(1.0f, 1.0f, 1.0f);
                else
                    TJAPlayer3.Tx.Difficulty_Bar.color4 = new Color4(0.5f, 0.5f, 0.5f);

                TJAPlayer3.Tx.Difficulty_Bar.t2D描画(TJAPlayer3.app.Device, 855, 270, new RectangleF(743, 0, 138, 236));

                if (TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[4] > 0)
                    t小文字表示(TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[4].ToString(), 498 + 3 * 143, 434.5f);

                for (int g = 0; g < TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[4]; g++)
                    if (TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[4] > 0)
                        TJAPlayer3.Tx.Difficulty_Star.t2D描画(TJAPlayer3.app.Device, 444 + 3 * 143 + g * 10, 459);
            }
            else
            {
                if (TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[3] > 0)
                    TJAPlayer3.Tx.Difficulty_Bar.color4 = new Color4(1.0f, 1.0f, 1.0f);
                else
                    TJAPlayer3.Tx.Difficulty_Bar.color4 = new Color4(0.5f, 0.5f, 0.5f);

                TJAPlayer3.Tx.Difficulty_Bar.t2D描画(TJAPlayer3.app.Device, 855, 270, new RectangleF(600, 0, 143, 236));

                if (TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[3] > 0)
                    t小文字表示(TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[3].ToString(), 498 + 3 * 143, 434.5f);

                for (int g = 0; g < TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[3]; g++)
                    if (TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nレベル[3] > 0)
                        TJAPlayer3.Tx.Difficulty_Star.t2D描画(TJAPlayer3.app.Device, 444 + 3 * 143 + g * 10, 459);
            }

            this.txTitle.t2D中心基準描画(TJAPlayer3.app.Device, 640, 140);
            this.txSubTitle.t2D中心基準描画(TJAPlayer3.app.Device, 640, 180);

            #region [ バーの描画 ]

            TJAPlayer3.Tx.Difficulty_Select_Bar.t2D描画(TJAPlayer3.app.Device, (float)this.BarX[n現在の選択行], 126 + ((float)Math.Sin((float)(ctBarAnimeIn.n現在の値 >= 80 ? (ctBarAnimeIn.n現在の値 - 80) : 0) * (Math.PI / 180)) * 50) + (float)Math.Sin((float)ctBarAnime.n現在の値 * (Math.PI / 180)) * 10, new RectangleF(0, 0, 259, 114));

            #endregion

            #endregion

            return 0;
        }

        // その他

        #region [ private ]
        //-----------------

        public bool bSelect;

        private CPrivateFastFont pfTitle;
        private CPrivateFastFont pfSubTitle;
        private CTexture txTitle;
        private CTexture txSubTitle;

        private CCounter ctBarAnimeIn;
        private CCounter ctBarAnime;

        //0 閉じる 1 演奏オプション 2~ 難易度
		private int n現在の選択行;
        private int nスイッチカウント;

        private bool b裏譜面;
        //176
        private int[] BarX = new int[] { 163, 251, 367, 510, 653, 797, 797 };

        private CSound soundSelectAnnounce;

        [StructLayout(LayoutKind.Sequential)]
        private struct STレベル数字
        {
            public char ch;
            public int ptX;
        }
        private STレベル数字[] st小文字位置 = new STレベル数字[10];

        private void t小文字表示(string str, float x, float y)
        {
            foreach (char ch in str)
            {
                for (int i = 0; i < this.st小文字位置.Length; i++)
                {
                    if (this.st小文字位置[i].ch == ch)
                    {
                        Rectangle rectangle = new Rectangle(this.st小文字位置[i].ptX, 0, 18, 23);
                        if (TJAPlayer3.Tx.Difficulty_Number != null)
                        {
                            TJAPlayer3.Tx.Difficulty_Number.t2D描画(TJAPlayer3.app.Device, x, y, rectangle);
                        }
                        break;
                    }
                }
                x += 11;
            }
        }

        public int nStrジャンルtoNum(string strジャンル)
        {
            int nGenre = 8;
            for (int i = 0; i < TJAPlayer3.Skin.SongSelect_GenreName.Length; i++)
            {
                if (TJAPlayer3.Skin.SongSelect_GenreName[i] == strジャンル)
                {
                    if (i + 1 >= TJAPlayer3.Skin.SongSelect_Difficulty_Background_Count)
                    {
                        nGenre = 0;
                    }
                    else
                    {
                        nGenre = i + 1;
                    }
                    break;
                }
                else
                {
                    nGenre = 0;
                }
            }
            return nGenre;
        }
        //-----------------
        #endregion
    }
}
