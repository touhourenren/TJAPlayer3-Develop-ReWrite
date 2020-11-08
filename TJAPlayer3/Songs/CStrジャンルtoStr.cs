namespace TJAPlayer3
{
    public static class CStrジャンルtoStr
    {
        public static string ForTextureFileName( string strジャンル )
        {
            switch (strジャンル)
            {
                case CStrジャンル.アニメ:
                    return "Anime";
                case CStrジャンル.ポップス:
                    return "Pops";
                case CStrジャンル.ゲームバラエティ:
                    return "GameVariety";
                case CStrジャンル.ナムコオリジナル:
                    return "Namco";
                case CStrジャンル.クラシック:
                    return "Classic";
                case CStrジャンル.キッズ:
                    return "Child";
                case CStrジャンル.ボーカロイドJP:
                case CStrジャンル.ボーカロイドEN:
                    return "Vocaloid";
                default:
                    return null;
            }
        }
    }
}