using SerialsOnlineCenter.DAL.FilterProperties;
using System.Text;

namespace SerialsOnlineCenter.DAL.QueryCreators.Serials
{
    internal class InitialState : IQueryState<SerialFilterProperties>
    {
        public StringBuilder Handle(StringBuilder sb, SerialFilterProperties properties)
        {
            IQueryState<SerialFilterProperties>.CurrentState = QueryStates.Initial;

            return new StringBuilder("SELECT * FROM serials ");
        }
    }
}
