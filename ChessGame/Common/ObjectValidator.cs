namespace ChessGame.Common
{
    using ChessGame.Common;
    using ChessGame.Figures.Contracts;
    using System;

    public static class ObjectValidator
    {
        public static void CheckIfObjectIsNull(Object obj, string errorMessage = GlobalConstants.EmptyString)
        {
            if(obj == null)
            {
                throw new NullReferenceException(errorMessage);
            }
        }
    }
   
}
