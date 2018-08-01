namespace Sjerrul.BrainFck.Machine.Parts
{
    public interface ITape
    {
        void MovePointerRight();
        void MovePointerLeft();
        void Increment();
        void Decrement();
        int Read();
    }
}
