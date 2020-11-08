namespace TJAPlayer3
{
    public static class CStrジャンルtoNum
    {
        public static int ForAC8_14SortOrder( string strジャンル )
        {
            switch( strジャンル )
            {
                case CStrジャンル.アニメ:
                    return 0;
                case CStrジャンル.ポップス:
                    return 1;
                case CStrジャンル.ゲームバラエティ:
                    return 2;
                case CStrジャンル.ナムコオリジナル:
                    return 3;
                case CStrジャンル.クラシック:
                    return 4;
                case CStrジャンル.キッズ:
                    return 5;
                case CStrジャンル.ボーカロイドJP:
                case CStrジャンル.ボーカロイドEN:
                    return 6;
                default:
                    return 7;
            }
        }

        public static EジャンルAC15SortOrder ForAC15SortOrder( string strジャンル )
        {
            switch ( strジャンル )
            {
                case CStrジャンル.ポップス:
                    return EジャンルAC15SortOrder.ポップス;
                case CStrジャンル.アニメ:
                    return EジャンルAC15SortOrder.アニメ;
                case CStrジャンル.ボーカロイドJP:
                case CStrジャンル.ボーカロイドEN:
                    return EジャンルAC15SortOrder.ボーカロイド;
                case CStrジャンル.キッズ:
                    return EジャンルAC15SortOrder.キッズ;
                case CStrジャンル.クラシック:
                    return EジャンルAC15SortOrder.クラシック;
                case CStrジャンル.ゲームバラエティ:
                    return EジャンルAC15SortOrder.ゲームバラエティ;
                case CStrジャンル.ナムコオリジナル:
                    return EジャンルAC15SortOrder.ナムコオリジナル;
                default:
                    return EジャンルAC15SortOrder.Unknown;
            }
        }

        public static int ForBarGenreIndex( string strジャンル )
        {
            return ForGenreBackIndex( strジャンル );
        }

        public static int ForFrameBoxIndex( string strジャンル )
        {
            return ForGenreBackIndex( strジャンル );
        }

        public static int ForGenreBackIndex( string strジャンル )
        {
            switch ( strジャンル )
            {
                case CStrジャンル.ポップス:
                    return 1;
                case CStrジャンル.アニメ:
                    return 2;
                case CStrジャンル.ゲームバラエティ:
                    return 3;
                case CStrジャンル.ナムコオリジナル:
                    return 4;
                case CStrジャンル.クラシック:
                    return 5;
                case CStrジャンル.キッズ:
                    return 6;
                case CStrジャンル.ボーカロイドJP:
                case CStrジャンル.ボーカロイドEN:
                    return 7;
                default:
                    return 0;
            }
        }

        public static int ForGenreTextIndex( string strジャンル )
        {
            return ForAC8_14SortOrder( strジャンル );
        }
    }
}