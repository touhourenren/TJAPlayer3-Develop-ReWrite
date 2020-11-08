using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using FDK;
using System;

namespace TJAPlayer3
{
	internal sealed class CActResultParameterPanel : CActivity
	{
		// コンストラクタ

		public CActResultParameterPanel()
		{
			ST文字位置[] st文字位置Array = new ST文字位置[ 11 ];
			ST文字位置 st文字位置 = new ST文字位置();
			st文字位置.ch = '0';
			st文字位置.pt = new Point( 0, 0 );
			st文字位置Array[ 0 ] = st文字位置;
			ST文字位置 st文字位置2 = new ST文字位置();
			st文字位置2.ch = '1';
			st文字位置2.pt = new Point( 32, 0 );
			st文字位置Array[ 1 ] = st文字位置2;
			ST文字位置 st文字位置3 = new ST文字位置();
			st文字位置3.ch = '2';
			st文字位置3.pt = new Point( 64, 0 );
			st文字位置Array[ 2 ] = st文字位置3;
			ST文字位置 st文字位置4 = new ST文字位置();
			st文字位置4.ch = '3';
			st文字位置4.pt = new Point( 96, 0 );
			st文字位置Array[ 3 ] = st文字位置4;
			ST文字位置 st文字位置5 = new ST文字位置();
			st文字位置5.ch = '4';
			st文字位置5.pt = new Point( 128, 0 );
			st文字位置Array[ 4 ] = st文字位置5;
			ST文字位置 st文字位置6 = new ST文字位置();
			st文字位置6.ch = '5';
			st文字位置6.pt = new Point( 160, 0 );
			st文字位置Array[ 5 ] = st文字位置6;
			ST文字位置 st文字位置7 = new ST文字位置();
			st文字位置7.ch = '6';
			st文字位置7.pt = new Point( 192, 0 );
			st文字位置Array[ 6 ] = st文字位置7;
			ST文字位置 st文字位置8 = new ST文字位置();
			st文字位置8.ch = '7';
			st文字位置8.pt = new Point( 224, 0 );
			st文字位置Array[ 7 ] = st文字位置8;
			ST文字位置 st文字位置9 = new ST文字位置();
			st文字位置9.ch = '8';
			st文字位置9.pt = new Point( 256, 0 );
			st文字位置Array[ 8 ] = st文字位置9;
			ST文字位置 st文字位置10 = new ST文字位置();
			st文字位置10.ch = '9';
			st文字位置10.pt = new Point( 288, 0 );
			st文字位置Array[ 9 ] = st文字位置10;
			ST文字位置 st文字位置11 = new ST文字位置();
			st文字位置11.ch = ' ';
			st文字位置11.pt = new Point( 0, 0 );
			st文字位置Array[ 10 ] = st文字位置11;
			this.st小文字位置 = st文字位置Array;

            ST文字位置[] stScore文字位置Array = new ST文字位置[10];
            ST文字位置 stScore文字位置 = new ST文字位置();
            stScore文字位置.ch = '0';
            stScore文字位置.pt = new Point(0, 0);
            stScore文字位置Array[0] = stScore文字位置;
            ST文字位置 stScore文字位置2 = new ST文字位置();
            stScore文字位置2.ch = '1';
            stScore文字位置2.pt = new Point(24, 0);
            stScore文字位置Array[1] = stScore文字位置2;
            ST文字位置 stScore文字位置3 = new ST文字位置();
            stScore文字位置3.ch = '2';
            stScore文字位置3.pt = new Point(48, 0);
            stScore文字位置Array[2] = stScore文字位置3;
            ST文字位置 stScore文字位置4 = new ST文字位置();
            stScore文字位置4.ch = '3';
            stScore文字位置4.pt = new Point(72, 0);
            stScore文字位置Array[3] = stScore文字位置4;
            ST文字位置 stScore文字位置5 = new ST文字位置();
            stScore文字位置5.ch = '4';
            stScore文字位置5.pt = new Point(96, 0);
            stScore文字位置Array[4] = stScore文字位置5;
            ST文字位置 stScore文字位置6 = new ST文字位置();
            stScore文字位置6.ch = '5';
            stScore文字位置6.pt = new Point(120, 0);
            stScore文字位置Array[5] = stScore文字位置6;
            ST文字位置 stScore文字位置7 = new ST文字位置();
            stScore文字位置7.ch = '6';
            stScore文字位置7.pt = new Point(144, 0);
            stScore文字位置Array[6] = stScore文字位置7;
            ST文字位置 stScore文字位置8 = new ST文字位置();
            stScore文字位置8.ch = '7';
            stScore文字位置8.pt = new Point(168, 0);
            stScore文字位置Array[7] = stScore文字位置8;
            ST文字位置 stScore文字位置9 = new ST文字位置();
            stScore文字位置9.ch = '8';
            stScore文字位置9.pt = new Point(192, 0);
            stScore文字位置Array[8] = stScore文字位置9;
            ST文字位置 stScore文字位置10 = new ST文字位置();
            stScore文字位置10.ch = '9';
            stScore文字位置10.pt = new Point(216, 0);
            stScore文字位置Array[9] = stScore文字位置10;
            this.stScoreFont = stScore文字位置Array;



			this.ptFullCombo位置 = new Point[] { new Point( 0x80, 0xed ), new Point( 0xdf, 0xed ), new Point( 0x141, 0xed ) };
			base.b活性化してない = true;
		}


		// メソッド

		public void tアニメを完了させる()
		{
			this.ct表示用.n現在の値 = this.ct表示用.n終了値;
		}
        private void tスコアアニメーション情報の初期化()
        {
            this.nScores = new string[] { TJAPlayer3.stage結果.st演奏記録.Drums.nスコア.ToString(), TJAPlayer3.stage結果.st演奏記録.Drums.nPerfect数.ToString(), TJAPlayer3.stage結果.st演奏記録.Drums.nGreat数.ToString(), TJAPlayer3.stage結果.st演奏記録.Drums.nMiss数.ToString(), TJAPlayer3.stage結果.st演奏記録.Drums.n最大コンボ数.ToString(), TJAPlayer3.stage結果.st演奏記録.Drums.n連打数.ToString() };
            this.ctMainTimer = new CCounter();

            for (int i = 0; i < 6; i++)
            {
                if (this.c数字アニメーション[i] == null)
                    this.c数字アニメーション[i] = new C数字アニメーション();
                if (i < this.c数字アニメーション.Length)
                    this.c数字アニメーション[i].b数字アニメ終了した = false;

                this.c数字アニメーション[i].n現在の桁数 = -1;

                if (this.c数字アニメーション[i].ct数字待機アニメ == null)
                {
                    this.c数字アニメーション[i].ct数字待機アニメ = new CCounter(0, TJAPlayer3.Skin.nScoreEndValueOfWaitingTime, TJAPlayer3.Skin.dbScoreWaitingTime, TJAPlayer3.Timer);
                    this.c数字アニメーション[i].ct数字終了アニメ = new CCounter(0, TJAPlayer3.Skin.nScoreEndValueOfEndTime, TJAPlayer3.Skin.dbScoreEndTime, TJAPlayer3.Timer);
                }
            }
            if (this.ct数字回転 == null)
                this.ct数字回転 = new CCounter();
        }

        // CActivity 実装

        public override void On活性化()
		{
			this.sdDTXで指定されたフルコンボ音 = null;
			this.bフルコンボ音再生済み = false;
			base.On活性化();
		}
		public override void On非活性化()
		{
			if( this.ct表示用 != null )
			{
				this.ct表示用 = null;
			}
            if (this.sdDTXで指定されたフルコンボ音 != null)
            {
                TJAPlayer3.Sound管理.tサウンドを破棄する(this.sdDTXで指定されたフルコンボ音);
                this.sdDTXで指定されたフルコンボ音 = null;
            }

            TJAPlayer3.Skin.sound数字回転音.t停止する();

            base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if( !base.b活性化してない )
			{
                tスコアアニメーション情報の初期化();
                Dan_Plate = TJAPlayer3.tテクスチャの生成(Path.GetDirectoryName(TJAPlayer3.DTX.strファイル名の絶対パス) + @"\Dan_Plate.png");
                base.OnManagedリソースの作成();
			}
		}
		public override void OnManagedリソースの解放()
		{
			if( !base.b活性化してない )
			{
                Dan_Plate?.Dispose();
                base.OnManagedリソースの解放();
			}
		}
		public override int On進行描画()
		{
			if( base.b活性化してない )
			{
				return 0;
			}
			if( base.b初めての進行描画 )
			{
                this.ctMainTimer = new CCounter(0, 999999999, 1, TJAPlayer3.Timer);
                this.ct数字回転 = new CCounter(0, 9, TJAPlayer3.Skin.dbNumberRotationSpeed, TJAPlayer3.Timer);
                this.ct表示用 = new CCounter( 0, 0x3e7, 2, TJAPlayer3.Timer );
				base.b初めての進行描画 = false;
			}

			ctMainTimer.t進行();
            ct数字回転.t進行Loop();
            ct表示用.t進行();
            
            TJAPlayer3.Tx.Result_Panel?.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.nResultPanelP1X, TJAPlayer3.Skin.nResultPanelP1Y);
            TJAPlayer3.Tx.Result_Score_Text?.t2D描画(TJAPlayer3.app.Device, 753, 249); //点
            TJAPlayer3.Tx.Result_Judge?.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.nResultJudge1_P1X, TJAPlayer3.Skin.nResultJudge1_P1Y);

            if(TJAPlayer3.Tx.Result_Gauge_Base != null && TJAPlayer3.Tx.Result_Gauge != null )
            {

                //int nRectX = (int)( CDTXMania.stage結果.st演奏記録.Drums.fゲージ / 2) * 12;
                double Rate = TJAPlayer3.stage結果.st演奏記録.Drums.fゲージ;
                //nRectX = CDTXMania.stage結果.st演奏記録.Drums.fゲージ >= 80.0f ? 80 : nRectX;


                //ハード/EXハードゲージ用のBase
                CTexture gaugeBase;
                switch (TJAPlayer3.ConfigIni.eGaugeMode)
                {
                    case EGaugeMode.ExHard:
                        gaugeBase = TJAPlayer3.Tx.Result_Gauge_Base_ExHard ?? TJAPlayer3.Tx.Result_Gauge_Base_Hard ?? TJAPlayer3.Tx.Result_Gauge_Base;
                        break;
                    case EGaugeMode.Hard:
                        gaugeBase = TJAPlayer3.Tx.Result_Gauge_Base_Hard ?? TJAPlayer3.Tx.Result_Gauge_Base;
                        break;
                    default:
                        gaugeBase = TJAPlayer3.Tx.Result_Gauge_Base;
                        break;
                }
                gaugeBase?.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.nResultGaugeBaseP1X, TJAPlayer3.Skin.nResultGaugeBaseP1Y, new Rectangle(0, 0, 691, 47));

                #region[ ゲージ本体 ]

                //ハードゲージ用のゲージ画像の分岐(ゲージ本体のコードを使いまわしたいので)
                CTexture gauge;
                if (TJAPlayer3.Tx.Result_Gauge_ExHard != null && TJAPlayer3.ConfigIni.eGaugeMode == EGaugeMode.ExHard)
                    gauge = TJAPlayer3.Tx.Result_Gauge_ExHard;
                else if (TJAPlayer3.Tx.Result_Gauge_Hard != null && (TJAPlayer3.ConfigIni.eGaugeMode == EGaugeMode.Hard || TJAPlayer3.ConfigIni.eGaugeMode == EGaugeMode.ExHard))
                    gauge = TJAPlayer3.Tx.Result_Gauge_Hard;
                else
                    gauge = TJAPlayer3.Tx.Result_Gauge;

                if (gauge != null)
                {
                    if ( Rate > 2 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 4 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 12, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 6 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 24, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 8 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 36, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 10 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 49, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 12 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 62, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 14 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 74, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 16 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 86, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 18 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 99, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 20 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 112, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 22 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 125, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 24 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 138, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 26 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 150, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 28 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 162, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 30 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 175, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 32 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 187, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 34 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 200, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 36 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 212, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 38 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 225, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 40 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 238, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 42 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 251, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 44 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 263, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 46 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 276, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 48 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 288, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 50 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 301, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 52 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 313, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 54 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 326, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 56 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 339, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 58 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 352, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 60 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 364, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 62 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 377, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 64 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 390, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 66 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 402, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 68 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 415, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 70 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 427, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 72 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 440, 145, new Rectangle( 0, 20, 12, 20 ) );
                    if( Rate > 74 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 452, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 76 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 465, 145, new Rectangle( 12, 20, 13, 20 ) );
                    if( Rate > 78 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 478, 145, new Rectangle( 12, 20, 13, 20 ) );

                    if( Rate > 80 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 491, 125, new Rectangle( 25, 0, 12, 40 ) );
                    if( Rate > 82 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 503, 125, new Rectangle( 49, 0, 13, 40 ) );
                    if( Rate > 84 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 516, 125, new Rectangle( 37, 0, 12, 40 ) );
                    if( Rate > 86 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 528, 125, new Rectangle( 49, 0, 13, 40 ) );
                    if( Rate > 88 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 541, 125, new Rectangle( 37, 0, 12, 40 ) );
                    if( Rate > 90 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 553, 125, new Rectangle( 49, 0, 13, 40 ) );
                    if( Rate > 92 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 566, 125, new Rectangle( 49, 0, 13, 40 ) );
                    if( Rate > 94 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 579, 125, new Rectangle( 37, 0, 12, 40 ) );
                    if( Rate > 96 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 591, 125, new Rectangle( 49, 0, 13, 40 ) );
                    if( Rate > 98 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 604, 125, new Rectangle( 37, 0, 12, 40 ) );
                    if( Rate >= 100 )
                        gauge.t2D描画( TJAPlayer3.app.Device, 559 + 616, 125, new Rectangle( 49, 0, 10, 40 ) );
                }

                #endregion
            }
            if(TJAPlayer3.Tx.Gauge_Soul != null )
            {
                if(TJAPlayer3.Tx.Gauge_Soul_Fire != null && TJAPlayer3.stage結果.st演奏記録.Drums.fゲージ >= 100.0f )
                    TJAPlayer3.Tx.Gauge_Soul_Fire.t2D描画( TJAPlayer3.app.Device, 1100, 34, new Rectangle( 0, 0, 230, 230 ) );
                TJAPlayer3.Tx.Gauge_Soul.t2D描画( TJAPlayer3.app.Device, 1174, 107, new Rectangle( 0, 0, 80, 80 ) );
            }
            //演奏中のやつ使いまわせなかった。ファック。
            if (this.ctMainTimer.n現在の値 >= TJAPlayer3.Skin.nScoreAnimeStartValue)
            {
                t数字アニメーション();
            }

            #region 段位認定モード用
            if (TJAPlayer3.stage選曲.n確定された曲の難易度 == (int)Difficulty.Dan)
            {
                TJAPlayer3.stage演奏ドラム画面.actDan.DrawExam(TJAPlayer3.stage結果.st演奏記録.Drums.Dan_C);
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
                // Dan_Plate
                Dan_Plate?.t2D中心基準描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_Dan_Plate_XY[0], TJAPlayer3.Skin.Result_Dan_Plate_XY[1]);
            }
            #endregion


            if ( !this.ct表示用.b終了値に達した )
			{
				return 0;
			}
			return 1;
		}
		

		// その他

		#region [ private ]
		//-----------------
		[StructLayout( LayoutKind.Sequential )]
		private struct ST文字位置
		{
			public char ch;
			public Point pt;
		}

		private bool bフルコンボ音再生済み;
		private CCounter ct表示用;
		private readonly Point[] ptFullCombo位置;
        private CSound sdDTXで指定されたフルコンボ音;
		private readonly ST文字位置[] st小文字位置;
        private ST文字位置[] stScoreFont;

        private CTexture Dan_Plate;

        private string[] nScores;
        private CCounter ctMainTimer;

        protected void tスコア文字表示(CTexture txScore, int x, int y, int n間隔, string str, ref CCounter ctスコア待機用, ref CCounter ctスコア終了用, ref int n現在の桁数, ref bool b数字アニメを終了した, bool isScore = false)
        {
            ctスコア待機用.t進行();
            ctスコア終了用.t進行();
            if (b数字アニメを終了した)
            {
                #region [ 終了用カウンターの処理 ]
                if (!ctスコア終了用.b進行中)
                {
                    ctスコア終了用.t進行();//終了用カウンターを動かす(本家では間隔が違ったので)
                    ctスコア終了用.n現在の値 = 0;//終了用カウンターを動かす
                }
                #endregion
            }
            else
            {
                #region [ ピッ！音の再生処理や停止処理 ]
                if (n現在の桁数 < str.Length - (str.Length > 1 ? 1 : 0))
                {
                    if (!TJAPlayer3.Skin.sound数字回転音.b再生中)
                        TJAPlayer3.Skin.sound数字回転音.t再生する();
                }
                if ((!ctスコア待機用.b進行中 || ctスコア待機用.n現在の値 == ctスコア待機用.n終了値))
                {
                    if (n現在の桁数 < str.Length && n現在の桁数 >= str.Length - 1)
                    {
                        TJAPlayer3.Skin.sound数字回転音.t停止する();
                        TJAPlayer3.Skin.sound決定音.t再生する();
                    }
                }
                #endregion
                #region [ 一文字ずつ増えていく仕組みをCCounterで再現 ]
                if ((!ctスコア待機用.b進行中 || ctスコア待機用.n現在の値 == ctスコア待機用.n終了値))//カウンターの一文字間隔カウンターが終了値に達したら。
                {
                    ctスコア待機用.t進行();//カウンターをループさせる
                    ctスコア待機用.n現在の値 = 0;//カウンターをループさせる

                    if (n現在の桁数 < str.Length)
                    {
                        if (n現在の桁数 >= str.Length - 1)
                        {
                            TJAPlayer3.Skin.sound数字回転音.t停止する();//ピッ！音を止める。
                            TJAPlayer3.Skin.sound決定音.t再生する();//ドン！音を再生。
                        }
                        n現在の桁数++;//1桁増やす。
                    }
                    else
                    {
                        b数字アニメを終了した = true;//終了処理のため終了したかを確認するbooleanをここで動かす！！！。。
                        n現在の桁数 = str.Length;//念のため、終わった時に参照されている文字列の桁数にセット。
                    }
                }
                #endregion
            }
            #region [ メインとなる数字 ]
            for (int nScore = 0; nScore < n現在の桁数; nScore++)
            {
                for (int i = 0; i < 10; i++)
                {
                    char[] chars = str.ToCharArray();
                    Array.Reverse(chars);
                    var ret = new string(chars);

                    if (char.Parse(i.ToString()) == ret.ToCharArray()[nScore])
                    {
                        if (txScore != null)
                        {
                            Rectangle rectangle = new Rectangle((int)(txScore.szテクスチャサイズ.Width / (10f + (!isScore ? 1f : 0f))) * i, 0, (int)(txScore.szテクスチャサイズ.Width / (10f + (!isScore ? 1f : 0f))), (int)(txScore.szテクスチャサイズ.Height / (!isScore ? 2f : 1f)));
                            txScore.t2D描画(TJAPlayer3.app.Device, x - (nScore * n間隔) + (isScore ? 155 : 65), y, rectangle);
                        }
                    }
                }
            }
            #endregion
            #region [ ぐるぐる回転する数字 ]
            if (n現在の桁数 < str.Length)
            {
                if (txScore != null)
                {
                    Rectangle rectangle = new Rectangle((int)(txScore.szテクスチャサイズ.Width / (10f + (!isScore ? 1f : 0f))) * this.ct数字回転.n現在の値, 0, (int)(txScore.szテクスチャサイズ.Width / (10f + (!isScore ? 1f : 0f))), (int)(txScore.szテクスチャサイズ.Height / (!isScore ? 2f : 1f)));
                    txScore.t2D描画(TJAPlayer3.app.Device, x - ((n現在の桁数) * n間隔) + (isScore ? 155 : 65), y, rectangle);
                }
            }
            #endregion
        }


        //-----------------
        #endregion

        private void t数字アニメーション()
        {
            #region [ キーが押されたら。。。 ]
            if (TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.RRed) || TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.LRed))
            {
                for (int i = 0; i < this.nScores.Length; i++)
                {
                    if (!this.c数字アニメーション[i].b数字アニメ終了した)
                    {
                        TJAPlayer3.Skin.sound数字回転音.t停止する();//ピッ！音を止める。
                        this.c数字アニメーション[i].n現在の桁数 = this.nScores[i].Length;
                        this.c数字アニメーション[i].b数字アニメ終了した = true;
                    }
                }
            }
            #endregion
            int[] nScoreY = new int[] { TJAPlayer3.Skin.nResultScoreP1Y, TJAPlayer3.Skin.nResultGreatP1Y, TJAPlayer3.Skin.nResultGoodP1Y, TJAPlayer3.Skin.nResultBadP1Y, TJAPlayer3.Skin.nResultComboP1Y, TJAPlayer3.Skin.nResultRollP1Y };
            int[] nScoreX = new int[] { TJAPlayer3.Skin.nResultScoreP1X, TJAPlayer3.Skin.nResultGreatP1X, TJAPlayer3.Skin.nResultGoodP1X, TJAPlayer3.Skin.nResultBadP1X, TJAPlayer3.Skin.nResultComboP1X, TJAPlayer3.Skin.nResultRollP1X };
            for (int i = 0; i < this.nScores.Length; i++)
            {
                if (i == 0)
                {
                    this.tスコア文字表示(TJAPlayer3.Tx.Result_Score_Number, nScoreX[0], nScoreY[0], 20, this.nScores[0], ref this.c数字アニメーション[i].ct数字待機アニメ, ref this.c数字アニメーション[i].ct数字終了アニメ, ref this.c数字アニメーション[i].n現在の桁数, ref this.c数字アニメーション[i].b数字アニメ終了した, true);
                    if (this.c数字アニメーション[i].b数字アニメ終了した ? this.c数字アニメーション[i].ct数字終了アニメ.n現在の値 < this.c数字アニメーション[i].ct数字終了アニメ.n終了値 : true)
                        return;
                }
                else
                {
                    this.tスコア文字表示(TJAPlayer3.Tx.Result_Number, nScoreX[i], nScoreY[i], 22, this.nScores[i], ref this.c数字アニメーション[i].ct数字待機アニメ, ref this.c数字アニメーション[i].ct数字終了アニメ, ref this.c数字アニメーション[i].n現在の桁数, ref this.c数字アニメーション[i].b数字アニメ終了した);
                    if (this.c数字アニメーション[i].b数字アニメ終了した ? this.c数字アニメーション[i].ct数字終了アニメ.n現在の値 < this.c数字アニメーション[i].ct数字終了アニメ.n終了値 : true)
                        return;
                }
            }
        }
        class C数字アニメーション
        {
            public bool b数字アニメ終了した;
            public int n現在の桁数;
            public CCounter ct数字待機アニメ;
            public CCounter ct数字終了アニメ;
        }
        private C数字アニメーション[] c数字アニメーション = new C数字アニメーション[8];
        private CCounter ct数字回転 = new CCounter();
    }
}
