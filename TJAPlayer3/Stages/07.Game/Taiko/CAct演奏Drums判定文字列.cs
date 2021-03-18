using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;
using SlimDX;
using FDK;
using System.Drawing;

namespace TJAPlayer3
{
	internal class CAct演奏Drums判定文字列 : CActivity
	{
		// コンストラクタ

		public CAct演奏Drums判定文字列()
		{
			base.b活性化してない = true;
		}

        public override void On活性化()
        {
			JudgeAnimes = new JudgeAnime[512];
			for (int i = 0; i < 512; i++)
            {
				JudgeAnimes[i] = new JudgeAnime();
            }
            base.On活性化();
        }

        public override void On非活性化()
        {
			for (int i = 0; i < 128; i++)
            {
				JudgeAnimes[i] = null;
            }
            base.On非活性化();
        }

        // CActivity 実装（共通クラスからの差分のみ）
        public override int On進行描画()
		{
			if (!base.b活性化してない)
			{
				for (int i = 0; i < 512; i++)
				{
					if (JudgeAnimes[i].counter.b停止中) continue;
					JudgeAnimes[i].counter.t進行();
					float x = TJAPlayer3.Skin.nScrollFieldX[0] - TJAPlayer3.Tx.Judge.szテクスチャサイズ.Width / 2;
					float y = (TJAPlayer3.Skin.nScrollFieldY[JudgeAnimes[JudgeAnime.Index].Player] - 53 + CubicEaseOut((float)(JudgeAnimes[i].counter.n現在の値 >= 180 ? 180 : JudgeAnimes[i].counter.n現在の値) / 180f) * 15f);
					TJAPlayer3.Tx.Judge.Opacity = (int)(255f - (JudgeAnimes[i].counter.n現在の値 >= 360 ? ((JudgeAnimes[i].counter.n現在の値 - 360) / 50.0f) * 255f : 0f));
					TJAPlayer3.Tx.Judge.t2D描画(TJAPlayer3.app.Device, x, y, JudgeAnimes[i].rc);
				}
			}
            return 0;
		}

		public void Start(int player, E判定 judge)
        {
			JudgeAnimes[JudgeAnime.Index].counter.t開始(0, 410, 1, TJAPlayer3.Timer);
			JudgeAnimes[JudgeAnime.Index].Judge = judge;
			JudgeAnimes[JudgeAnime.Index].Player = player;
			int njudge = judge == E判定.Perfect ? 0 : judge == E判定.Good ? 1 : 2;
			JudgeAnimes[JudgeAnime.Index].rc = new Rectangle(0, (int)njudge * 60, 90, 60);
			if(JudgeAnime.Index >= 2)
			{
				if (JudgeAnimes[JudgeAnime.Index - 2].counter.b終了値に達した)
				{
					JudgeAnime.Index++;
					if (JudgeAnime.Index >= 511) JudgeAnime.Index = 0;
				}
			}
		}

		// その他

		#region [ private ]
		//-----------------

		private JudgeAnime[] JudgeAnimes;
		private class JudgeAnime
        {
			public static int Index;
			public int Player;
			public E判定 Judge;
			public Rectangle rc;
			public CCounter counter = new CCounter();
		}

		private float CubicEaseOut(float p)
		{
			float f = (p - 1);
			return f * f * f + 1;
		}
		//-----------------
		#endregion
	}
}
