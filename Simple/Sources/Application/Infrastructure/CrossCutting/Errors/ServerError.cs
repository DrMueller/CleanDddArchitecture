namespace Mmu.CleanDddSimple.Infrastructure.CrossCutting.Errors
{
    public abstract class ServerError
    {
        public abstract string ToDescription();
    }
}