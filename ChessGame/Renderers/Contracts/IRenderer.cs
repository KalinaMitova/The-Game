namespace ChessGame.Renderers.Contracts
{
    using ChessGame.Board.Contracts;

    public interface IRenderer
    {
        void RenderBoard(IBoard board);
    }
}
