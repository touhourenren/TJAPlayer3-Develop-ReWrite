using FDK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJAPlayer3
{
    class CNamePlate
    {
        public CNamePlate()
        {
            for (int player = 0; player < 2; player++)
            {
                if (TJAPlayer3.NamePlateConfig.data.DanType[player] < 0) TJAPlayer3.NamePlateConfig.data.DanType[player] = 0;
                else if (TJAPlayer3.NamePlateConfig.data.DanType[player] > 2) TJAPlayer3.NamePlateConfig.data.DanType[player] = 2;

                if (TJAPlayer3.NamePlateConfig.data.TitleType[player] < 0) TJAPlayer3.NamePlateConfig.data.TitleType[player] = 0;
                else if (TJAPlayer3.NamePlateConfig.data.TitleType[player] > 2) TJAPlayer3.NamePlateConfig.data.TitleType[player] = 2;

                if (!string.IsNullOrEmpty(TJAPlayer3.ConfigIni.FontName))
                {
                    if (TJAPlayer3.NamePlateConfig.data.Title[player] == "" || TJAPlayer3.NamePlateConfig.data.Title[player] == null)
                        this.pfName = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 15);
                    else
                        this.pfName = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 12);

                    this.pfTitle = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 11);
                    this.pfdan = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 12);
                }
                else
                {
                    if (TJAPlayer3.NamePlateConfig.data.Title[player] == "" || TJAPlayer3.NamePlateConfig.data.Title[player] == null)
                        this.pfName = new CPrivateFastFont(new FontFamily("MS UI Gothic"), 15);
                    else
                        this.pfName = new CPrivateFastFont(new FontFamily("MS UI Gothic"), 12);

                    this.pfTitle = new CPrivateFastFont(new FontFamily("MS UI Gothic"), 11);
                    this.pfdan = new CPrivateFastFont(new FontFamily("MS UI Gothic"), 12);
                }

                using (var tex = pfName.DrawPrivateFont(TJAPlayer3.NamePlateConfig.data.Name[player], Color.White, Color.Black, 25))
                    txName[player] = TJAPlayer3.tテクスチャの生成(tex);

                using (var tex = pfTitle.DrawPrivateFont(TJAPlayer3.NamePlateConfig.data.Title[player], Color.Black, Color.Empty))
                    txTitle[player] = TJAPlayer3.tテクスチャの生成(tex);

                using (var tex = pfdan.DrawPrivateFont(TJAPlayer3.NamePlateConfig.data.Dan[player], Color.White, Color.Black, 22))
                    txdan[player] = TJAPlayer3.tテクスチャの生成(tex);
            }
        }

        public void tNamePlateDraw(int x, int y, int player)
        {
            //220, 54
            TJAPlayer3.Tx.NamePlateBase.t2D描画(TJAPlayer3.app.Device, x, y, new RectangleF(0, 3 * 54, 220, 54));

            if (TJAPlayer3.NamePlateConfig.data.Dan[player] != "" && TJAPlayer3.NamePlateConfig.data.Dan[player] != null)
            {
                if (TJAPlayer3.NamePlateConfig.data.Title[player] != "" && TJAPlayer3.NamePlateConfig.data.Title[player] != null)
                    TJAPlayer3.Tx.NamePlateBase.t2D描画(TJAPlayer3.app.Device, x, y, new RectangleF(0, (4 + TJAPlayer3.NamePlateConfig.data.TitleType[player]) * 54, 220, 54));
            }

            if (TJAPlayer3.NamePlateConfig.data.Dan[player] != "" && TJAPlayer3.NamePlateConfig.data.Dan[player] != null)
            {
                TJAPlayer3.Tx.NamePlateBase.t2D描画(TJAPlayer3.app.Device, x, y, new RectangleF(0, 7 * 54, 220, 54));
                TJAPlayer3.Tx.NamePlateBase.t2D描画(TJAPlayer3.app.Device, x, y, new RectangleF(0, (8 + TJAPlayer3.NamePlateConfig.data.DanType[player]) * 54, 220, 54));
            }

            TJAPlayer3.Tx.NamePlateBase.t2D描画(TJAPlayer3.app.Device, x, y, new RectangleF(0, player == 1 ? 2 * 54 : 0, 220, 54));

            if (TJAPlayer3.NamePlateConfig.data.Dan[player] != "" && TJAPlayer3.NamePlateConfig.data.Dan[player] != null)
            {
                if (txName[player].szテクスチャサイズ.Width >= 120.0f)
                    txName[player].vc拡大縮小倍率.X = 120.0f / txName[player].szテクスチャサイズ.Width;
            }
            else
            { 
                if (txName[player].szテクスチャサイズ.Width >= 220.0f)
                    txName[player].vc拡大縮小倍率.X = 220.0f / txName[player].szテクスチャサイズ.Width;
            }

            if (txdan[player].szテクスチャサイズ.Width >= 66.0f)
                txdan[player].vc拡大縮小倍率.X = 66.0f / txdan[player].szテクスチャサイズ.Width;

            if (TJAPlayer3.NamePlateConfig.data.Dan[player] != "" && TJAPlayer3.NamePlateConfig.data.Dan[player] != null)
            {
                this.txdan[player].t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 69, y + 45);
                if (TJAPlayer3.NamePlateConfig.data.DanGold[player])
                {
                    TJAPlayer3.Tx.NamePlateBase.b乗算合成 = true;
                    TJAPlayer3.Tx.NamePlateBase.t2D描画(TJAPlayer3.app.Device, x, y, new RectangleF(0, 11 * 54, 220, 54));
                    TJAPlayer3.Tx.NamePlateBase.b乗算合成 = false;
                }
            }

            if (TJAPlayer3.NamePlateConfig.data.Title[player] != "" && TJAPlayer3.NamePlateConfig.data.Title[player] != null)
            {
                if (txTitle[player].szテクスチャサイズ.Width >= 160)
                {
                    txTitle[player].vc拡大縮小倍率.X = 160.0f / txTitle[player].szテクスチャサイズ.Width;
                    txTitle[player].vc拡大縮小倍率.Y = 160.0f / txTitle[player].szテクスチャサイズ.Width;
                }

                txTitle[player].t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 124, y + 21);
                if (TJAPlayer3.NamePlateConfig.data.Dan[player] == "" || TJAPlayer3.NamePlateConfig.data.Dan[player] == null)
                    this.txName[player].t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 121, y + 46);
                else
                    this.txName[player].t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 144, y + 46);
            }
            else
                this.txName[player].t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 121, y + 38);
        }

        private CPrivateFastFont pfName;
        private CPrivateFastFont pfTitle;
        private CPrivateFastFont pfdan;
        private CTexture[] txName = new CTexture[2];
        private CTexture[] txTitle = new CTexture[2];
        private CTexture[] txdan = new CTexture[2];
    }
}
