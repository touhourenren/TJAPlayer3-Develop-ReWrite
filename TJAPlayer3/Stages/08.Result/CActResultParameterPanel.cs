using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using SlimDX;
using FDK;

namespace TJAPlayer3
{
	internal class CActResultParameterPanel : CActivity
	{
		// コンストラクタ

		public CActResultParameterPanel()
		{
			ST文字位置[] st文字位置Array = new ST文字位置[11];
			ST文字位置 st文字位置 = new ST文字位置();
			st文字位置.ch = '0';
			st文字位置.pt = new Point(0, 0);
			st文字位置Array[0] = st文字位置;
			ST文字位置 st文字位置2 = new ST文字位置();
			st文字位置2.ch = '1';
			st文字位置2.pt = new Point(32, 0);
			st文字位置Array[1] = st文字位置2;
			ST文字位置 st文字位置3 = new ST文字位置();
			st文字位置3.ch = '2';
			st文字位置3.pt = new Point(64, 0);
			st文字位置Array[2] = st文字位置3;
			ST文字位置 st文字位置4 = new ST文字位置();
			st文字位置4.ch = '3';
			st文字位置4.pt = new Point(96, 0);
			st文字位置Array[3] = st文字位置4;
			ST文字位置 st文字位置5 = new ST文字位置();
			st文字位置5.ch = '4';
			st文字位置5.pt = new Point(128, 0);
			st文字位置Array[4] = st文字位置5;
			ST文字位置 st文字位置6 = new ST文字位置();
			st文字位置6.ch = '5';
			st文字位置6.pt = new Point(160, 0);
			st文字位置Array[5] = st文字位置6;
			ST文字位置 st文字位置7 = new ST文字位置();
			st文字位置7.ch = '6';
			st文字位置7.pt = new Point(192, 0);
			st文字位置Array[6] = st文字位置7;
			ST文字位置 st文字位置8 = new ST文字位置();
			st文字位置8.ch = '7';
			st文字位置8.pt = new Point(224, 0);
			st文字位置Array[7] = st文字位置8;
			ST文字位置 st文字位置9 = new ST文字位置();
			st文字位置9.ch = '8';
			st文字位置9.pt = new Point(256, 0);
			st文字位置Array[8] = st文字位置9;
			ST文字位置 st文字位置10 = new ST文字位置();
			st文字位置10.ch = '9';
			st文字位置10.pt = new Point(288, 0);
			st文字位置Array[9] = st文字位置10;
			ST文字位置 st文字位置11 = new ST文字位置();
			st文字位置11.ch = ' ';
			st文字位置11.pt = new Point(0, 0);
			st文字位置Array[10] = st文字位置11;
			this.st小文字位置 = st文字位置Array;

			ST文字位置[] st文字位置Array2 = new ST文字位置[11];
			ST文字位置 st文字位置12 = new ST文字位置();
			st文字位置12.ch = '0';
			st文字位置12.pt = new Point(0, 0);
			st文字位置Array2[0] = st文字位置12;
			ST文字位置 st文字位置13 = new ST文字位置();
			st文字位置13.ch = '1';
			st文字位置13.pt = new Point(32, 0);
			st文字位置Array2[1] = st文字位置13;
			ST文字位置 st文字位置14 = new ST文字位置();
			st文字位置14.ch = '2';
			st文字位置14.pt = new Point(64, 0);
			st文字位置Array2[2] = st文字位置14;
			ST文字位置 st文字位置15 = new ST文字位置();
			st文字位置15.ch = '3';
			st文字位置15.pt = new Point(96, 0);
			st文字位置Array2[3] = st文字位置15;
			ST文字位置 st文字位置16 = new ST文字位置();
			st文字位置16.ch = '4';
			st文字位置16.pt = new Point(128, 0);
			st文字位置Array2[4] = st文字位置16;
			ST文字位置 st文字位置17 = new ST文字位置();
			st文字位置17.ch = '5';
			st文字位置17.pt = new Point(160, 0);
			st文字位置Array2[5] = st文字位置17;
			ST文字位置 st文字位置18 = new ST文字位置();
			st文字位置18.ch = '6';
			st文字位置18.pt = new Point(192, 0);
			st文字位置Array2[6] = st文字位置18;
			ST文字位置 st文字位置19 = new ST文字位置();
			st文字位置19.ch = '7';
			st文字位置19.pt = new Point(224, 0);
			st文字位置Array2[7] = st文字位置19;
			ST文字位置 st文字位置20 = new ST文字位置();
			st文字位置20.ch = '8';
			st文字位置20.pt = new Point(256, 0);
			st文字位置Array2[8] = st文字位置20;
			ST文字位置 st文字位置21 = new ST文字位置();
			st文字位置21.ch = '9';
			st文字位置21.pt = new Point(288, 0);
			st文字位置Array2[9] = st文字位置21;
			ST文字位置 st文字位置22 = new ST文字位置();
			st文字位置22.ch = '%';
			st文字位置22.pt = new Point(0x37, 0);
			st文字位置Array2[10] = st文字位置22;
			this.st大文字位置 = st文字位置Array2;

			ST文字位置[] stScore文字位置Array = new ST文字位置[10];
			ST文字位置 stScore文字位置 = new ST文字位置();
			stScore文字位置.ch = '0';
			stScore文字位置.pt = new Point(0, 0);
			stScore文字位置Array[0] = stScore文字位置;
			ST文字位置 stScore文字位置2 = new ST文字位置();
			stScore文字位置2.ch = '1';
			stScore文字位置2.pt = new Point(51, 0);
			stScore文字位置Array[1] = stScore文字位置2;
			ST文字位置 stScore文字位置3 = new ST文字位置();
			stScore文字位置3.ch = '2';
			stScore文字位置3.pt = new Point(102, 0);
			stScore文字位置Array[2] = stScore文字位置3;
			ST文字位置 stScore文字位置4 = new ST文字位置();
			stScore文字位置4.ch = '3';
			stScore文字位置4.pt = new Point(153, 0);
			stScore文字位置Array[3] = stScore文字位置4;
			ST文字位置 stScore文字位置5 = new ST文字位置();
			stScore文字位置5.ch = '4';
			stScore文字位置5.pt = new Point(204, 0);
			stScore文字位置Array[4] = stScore文字位置5;
			ST文字位置 stScore文字位置6 = new ST文字位置();
			stScore文字位置6.ch = '5';
			stScore文字位置6.pt = new Point(255, 0);
			stScore文字位置Array[5] = stScore文字位置6;
			ST文字位置 stScore文字位置7 = new ST文字位置();
			stScore文字位置7.ch = '6';
			stScore文字位置7.pt = new Point(306, 0);
			stScore文字位置Array[6] = stScore文字位置7;
			ST文字位置 stScore文字位置8 = new ST文字位置();
			stScore文字位置8.ch = '7';
			stScore文字位置8.pt = new Point(357, 0);
			stScore文字位置Array[7] = stScore文字位置8;
			ST文字位置 stScore文字位置9 = new ST文字位置();
			stScore文字位置9.ch = '8';
			stScore文字位置9.pt = new Point(408, 0);
			stScore文字位置Array[8] = stScore文字位置9;
			ST文字位置 stScore文字位置10 = new ST文字位置();
			stScore文字位置10.ch = '9';
			stScore文字位置10.pt = new Point(459, 0);
			stScore文字位置Array[9] = stScore文字位置10;
			this.stScoreFont = stScore文字位置Array;



			this.ptFullCombo位置 = new Point[] { new Point(0x80, 0xed), new Point(0xdf, 0xed), new Point(0x141, 0xed) };
			base.b活性化してない = true;
		}


		// メソッド

		public void tアニメを完了させる()
		{
			this.ct表示用.n現在の値 = (int)this.ct表示用.n終了値;
		}


		// CActivity 実装

		public override void On活性化()
		{
			this.sdDTXで指定されたフルコンボ音 = null;
			base.On活性化();
		}
		public override void On非活性化()
		{
			if (this.ct表示用 != null)
			{
				this.ct表示用 = null;
			}

			for(int i = 0; i < this.b音声再生.Length; i++)
            {
				b音声再生[i] = false;
            }

			if (this.sdDTXで指定されたフルコンボ音 != null)
			{
				TJAPlayer3.Sound管理.tサウンドを破棄する(this.sdDTXで指定されたフルコンボ音);
				this.sdDTXで指定されたフルコンボ音 = null;
			}
			base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if (!base.b活性化してない)
			{
				ct全体進行 = new CCounter(0, 20000, 1, TJAPlayer3.Timer);

				ctゲージアニメ = new CCounter();
				ct虹ゲージアニメ = new CCounter();

				ctSoul = new CCounter();

				Dan_Plate = TJAPlayer3.tテクスチャの生成(Path.GetDirectoryName(TJAPlayer3.DTX.strファイル名の絶対パス) + @"\Dan_Plate.png");

				base.OnManagedリソースの作成();
			}
		}
		public override void OnManagedリソースの解放()
		{
			if (!base.b活性化してない)
			{
				Dan_Plate?.Dispose();
				base.OnManagedリソースの解放();
			}
		}
		public override int On進行描画()
		{
			if (base.b活性化してない)
			{
				return 0;
			}
			if (base.b初めての進行描画)
			{
				this.ct表示用 = new CCounter(0, 0x3e7, 2, TJAPlayer3.Timer);
				base.b初めての進行描画 = false;
			}

			ct全体進行.t進行();
			ctゲージアニメ.t進行();

			if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan)
			{
				#region [ 通常時リザルト ]

				int AnimeCount = 3000 + (int)ctゲージアニメ.n終了値 * 59;

				TJAPlayer3.Tx.Result_Panel.t2D描画(TJAPlayer3.app.Device, 0, 0);

				TJAPlayer3.Tx.Result_Diff_Bar.t2D描画(TJAPlayer3.app.Device, 18, 101, new RectangleF(0, TJAPlayer3.stage選曲.n確定された曲の難易度[0] * 54, 185, 54));

				TJAPlayer3.Tx.Result_Gauge_Base.t2D描画(TJAPlayer3.app.Device, 55, 140);

				if (ct全体進行.n現在の値 >= 2000)
                {
                    #region [ ゲージ関連 ]

                    if (!b音声再生[0])
					{
						TJAPlayer3.Skin.soundGauge.t再生する();
						b音声再生[0] = true;
					}

					if (!ctゲージアニメ.b進行中)
						ctゲージアニメ.t開始(0, (int)TJAPlayer3.stage結果.st演奏記録.Drums.fゲージ / 2, 59, TJAPlayer3.Timer);

					TJAPlayer3.Tx.Result_Gauge.t2D描画(TJAPlayer3.app.Device, 57, 140, new RectangleF(0, 0, 9.74f * ctゲージアニメ.n現在の値, 36));

					if (ctゲージアニメ.b終了値に達した)
                    {
						if(ctゲージアニメ.n現在の値 != 50)
							TJAPlayer3.Skin.soundGauge.t停止する();
                        else
						{
							if (!TJAPlayer3.Skin.soundGauge.b再生中)
								TJAPlayer3.Skin.soundGauge.t停止する();

							if (!ct虹ゲージアニメ.b進行中)
								ct虹ゲージアニメ.t開始(0, 40, 1000 / 60, TJAPlayer3.Timer);

							if (!ctSoul.b進行中)
								ctSoul.t開始(0, 8, 33, TJAPlayer3.Timer);

							ct虹ゲージアニメ.t進行Loop();
							ctSoul.t進行Loop();

							TJAPlayer3.Tx.Result_Rainbow[ct虹ゲージアニメ.n現在の値].t2D描画(TJAPlayer3.app.Device, 57, 144);

							TJAPlayer3.Tx.Result_Soul_Fire.t2D中心基準描画(TJAPlayer3.app.Device, 576, 160, new Rectangle(150 * ctSoul.n現在の値, 0, 150, 131));

							TJAPlayer3.Tx.Result_Soul_Text.t2D中心基準描画(TJAPlayer3.app.Device, 575, 159, new Rectangle(37 * 1, 0, 37, 37));

							if (ctSoul.n現在の値 % 2 == 0)
								TJAPlayer3.Tx.Result_Soul_Text.t2D中心基準描画(TJAPlayer3.app.Device, 575, 159, new Rectangle(37 * 2, 0, 37, 37));
						}
					}

					#endregion
				}

				if (ct全体進行.n現在の値 >= 2000)
				{
					#region [ 成績(スコアを除く)関連 ]

					int Interval = 420;

					float AddCount = 135;

					if (ct全体進行.n現在の値 >= AnimeCount)
					{
						TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - AnimeCount) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
						TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - AnimeCount) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
						this.t小文字表示(TJAPlayer3.Skin.nResultNumberP1X, TJAPlayer3.Skin.nResultNumberY + TJAPlayer3.Skin.nResultNumberYPadding * 0, string.Format("{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.nPerfect数.ToString()));
						if (!this.b音声再生[1])
						{
							TJAPlayer3.Skin.soundPon.t再生する();
							this.b音声再生[1] = true;
						}
					}
					if (ct全体進行.n現在の値 >= AnimeCount + Interval)
					{
						TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount + Interval + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
						TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount + Interval + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
						this.t小文字表示(TJAPlayer3.Skin.nResultNumberP1X, TJAPlayer3.Skin.nResultNumberY + TJAPlayer3.Skin.nResultNumberYPadding * 1, string.Format("{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.nGreat数.ToString()));
						if (!this.b音声再生[2])
						{
							TJAPlayer3.Skin.soundPon.t再生する();
							this.b音声再生[2] = true;
						}
					}
					if (ct全体進行.n現在の値 >= AnimeCount + Interval * 2)
					{
						TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount + Interval * 2 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 2)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
						TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount + Interval * 2 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 2)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
						this.t小文字表示(TJAPlayer3.Skin.nResultNumberP1X, TJAPlayer3.Skin.nResultNumberY + TJAPlayer3.Skin.nResultNumberYPadding * 2, string.Format("{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.nMiss数.ToString()));
						if (!this.b音声再生[3])
						{
							TJAPlayer3.Skin.soundPon.t再生する();
							this.b音声再生[3] = true;
						}
					}
					if (ct全体進行.n現在の値 >= AnimeCount + Interval * 3)
					{
						TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount + Interval * 3 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 3)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
						TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount + Interval * 3 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 3)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
						this.t小文字表示(TJAPlayer3.Skin.nResultNumberP1X, TJAPlayer3.Skin.nResultNumberY + TJAPlayer3.Skin.nResultNumberYPadding * 3, string.Format("{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.n連打数.ToString()));
						if (!this.b音声再生[4])
						{
							TJAPlayer3.Skin.soundPon.t再生する();
							this.b音声再生[4] = true;
						}
					}
					if (ct全体進行.n現在の値 >= AnimeCount + Interval * 4)
					{
						TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount + Interval * 4 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 4)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
						TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount + Interval * 4 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 4)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
						this.t小文字表示(TJAPlayer3.Skin.nResultNumberP1X, TJAPlayer3.Skin.nResultNumberY + TJAPlayer3.Skin.nResultNumberYPadding * 4, string.Format("{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.n最大コンボ数.ToString()));
						if (!this.b音声再生[5])
						{
							TJAPlayer3.Skin.soundPon.t再生する();
							this.b音声再生[5] = true;
						}
					}

					#endregion

					#region [ スコア関連 ]

					if (ct全体進行.n現在の値 >= AnimeCount + Interval * 4 + 840)
					{
						int AnimeCount1 = AnimeCount + Interval * 4 + 840;

						TJAPlayer3.Tx.Result_Score_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount1 + 270 ? 1.0f + (float)Math.Sin((ct全体進行.n現在の値 - AnimeCount1) / 1.5f * (Math.PI / 180)) * 0.65f :
																		  ct全体進行.n現在の値 <= AnimeCount1 + 360 ? 1.0f - (float)Math.Sin((ct全体進行.n現在の値 - AnimeCount1 - 270) * (Math.PI / 180)) * 0.1f : 1.0f;
						TJAPlayer3.Tx.Result_Score_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount1 + 270 ? 1.0f + (float)Math.Sin((ct全体進行.n現在の値 - AnimeCount1) / 1.5f * (Math.PI / 180)) * 0.65f :
																		  ct全体進行.n現在の値 <= AnimeCount1 + 360 ? 1.0f - (float)Math.Sin((ct全体進行.n現在の値 - AnimeCount1 - 270) * (Math.PI / 180)) * 0.1f : 1.0f;

						this.tスコア文字表示(TJAPlayer3.Skin.nResultScoreP1X, TJAPlayer3.Skin.nResultScoreP1Y, string.Format("{0,7:######0}", TJAPlayer3.stage結果.st演奏記録.Drums.nスコア));

						if (!b音声再生[6])
						{
							TJAPlayer3.Skin.soundScoreDon.t再生する();
							b音声再生[6] = true;
						}
					}

					#endregion
				}

                if (ctゲージアニメ.n現在の値 != 50)
				{
					TJAPlayer3.Tx.Result_Gauge.t2D描画(TJAPlayer3.app.Device, 441, 142, new RectangleF(ctゲージアニメ.n現在の値 < 40 ? 0 : 42, 35, 42, 20));

					TJAPlayer3.Tx.Result_Soul_Text.t2D中心基準描画(TJAPlayer3.app.Device, 575, 159, new Rectangle(37 * (ctゲージアニメ.n現在の値 <= 30 ? 0 : 1), 0, 37, 37));
				}

				#endregion
			}
			else
			{
				#region 段位時リザルト

				switch (TJAPlayer3.stage演奏ドラム画面.actDan.GetExamStatus(TJAPlayer3.stage結果.st演奏記録.Drums.Dan_C))
				{
					case Exam.Status.Failure:
						TJAPlayer3.Tx.Result_Dan?.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_Dan_XY[0], TJAPlayer3.Skin.Result_Dan_XY[1], new Rectangle(0, 0, TJAPlayer3.Skin.Result_Dan[0], TJAPlayer3.Skin.Result_Dan[1]));
						break;
					case Exam.Status.Success:
						TJAPlayer3.Tx.Result_Dan?.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_Dan_XY[0], TJAPlayer3.Skin.Result_Dan_XY[1], new Rectangle(TJAPlayer3.Skin.Result_Dan[0], 0, TJAPlayer3.Skin.Result_Dan[0], TJAPlayer3.Skin.Result_Dan[1]));
						break;
					case Exam.Status.Better_Success:
						TJAPlayer3.Tx.Result_Dan?.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_Dan_XY[0], TJAPlayer3.Skin.Result_Dan_XY[1], new Rectangle(TJAPlayer3.Skin.Result_Dan[0] * 2, 0, TJAPlayer3.Skin.Result_Dan[0], TJAPlayer3.Skin.Result_Dan[1]));
						break;
					default:
						break;
				}

				Dan_Plate?.t2D中心基準描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_Dan_Plate_XY[0], TJAPlayer3.Skin.Result_Dan_Plate_XY[1]);

				#endregion
			}

			if (!this.ct表示用.b終了値に達した)
			{
				return 0;
			}
			return 1;
		}



		// その他

		#region [ private ]
		//-----------------
		[StructLayout(LayoutKind.Sequential)]
		private struct ST文字位置
		{
			public char ch;
			public Point pt;
		}

		private CCounter ct全体進行;
		private CCounter ctゲージアニメ;
		private CCounter ct虹ゲージアニメ;
		private CCounter ctSoul;

		public bool[] b音声再生 = { false, false, false, false, false, false, false, false, false };
		
		private CCounter ct表示用;
		private readonly Point[] ptFullCombo位置;
		private CSound sdDTXで指定されたフルコンボ音;
		private readonly ST文字位置[] st小文字位置;
		private readonly ST文字位置[] st大文字位置;
		private ST文字位置[] stScoreFont;

		private CTexture Dan_Plate;

		private void t小文字表示(int x, int y, string str)
		{
			foreach (char ch in str)
			{
				for (int i = 0; i < this.st小文字位置.Length; i++)
				{
					if (ch == ' ')
					{
						break;
					}

					if (this.st小文字位置[i].ch == ch)
					{
						Rectangle rectangle = new Rectangle(this.st小文字位置[i].pt.X, this.st小文字位置[i].pt.Y, 32, 38);
						if (TJAPlayer3.Tx.Result_Number != null)
						{
							TJAPlayer3.Tx.Result_Number.t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 16, y + 19, rectangle);
						}
						break;
					}
				}
				x += 22;
			}
		}
		private void t大文字表示(int x, int y, string str)
		{
			this.t大文字表示(x, y, str, false);
		}
		private void t大文字表示(int x, int y, string str, bool b強調)
		{
			foreach (char ch in str)
			{
				for (int i = 0; i < this.st大文字位置.Length; i++)
				{
					if (this.st大文字位置[i].ch == ch)
					{
						Rectangle rectangle = new Rectangle(this.st大文字位置[i].pt.X, this.st大文字位置[i].pt.Y, 11, 0x10);
						if (ch == '.')
						{
							rectangle.Width -= 2;
							rectangle.Height -= 2;
						}
						if (TJAPlayer3.Tx.Result_Number != null)
						{
							TJAPlayer3.Tx.Result_Number.t2D描画(TJAPlayer3.app.Device, x, y, rectangle);
						}
						break;
					}
				}
				x += 8;
			}
		}

		protected void tスコア文字表示(int x, int y, string str)
		{
			foreach (char ch in str)
			{
				for (int i = 0; i < this.stScoreFont.Length; i++)
				{
					if (this.stScoreFont[i].ch == ch)
					{
						Rectangle rectangle = new Rectangle(this.stScoreFont[i].pt.X, 0, 51, 60);
						if (TJAPlayer3.Tx.Result_Score_Number != null)
						{
							TJAPlayer3.Tx.Result_Score_Number.t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x - (str.Length * 33) + 25, y + 30, rectangle);
						}
						break;
					}
				}
				x += 33;
			}
		}
		//-----------------
		#endregion
	}
}
