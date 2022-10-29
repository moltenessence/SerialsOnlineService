using SerialsOnlineCenter.DAL.Interfaces.FilterProperties;
using System.Text;

namespace SerialsOnlineCenter.DAL.QueryCreators
{
    internal interface IQueryState<in TProperties> where TProperties : class, IFilterProperties
    {
        static QueryStates CurrentState = QueryStates.Initial;
        StringBuilder Handle(StringBuilder sb, TProperties properties);
    }
}
