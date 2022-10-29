using SerialsOnlineCenter.DAL.FilterProperties;
using System.Text;

namespace SerialsOnlineCenter.DAL.QueryCreators.Serials
{
    public class FindByAmountOfSeriesState : IQueryState<SerialFilterProperties>
    {
        private const string condition = "amount_of_series > @AmountOfSeries";

        public StringBuilder Handle(StringBuilder sb, SerialFilterProperties properties)
        {
            if (properties?.AmountOfSeries > 0)
            {
                switch (IQueryState<SerialFilterProperties>.CurrentState)
                {
                    case QueryStates.HasWhereCondition:
                        {
                            sb.Append($"AND {condition} ");

                            return sb;
                        }
                    case QueryStates.Initial:
                        {
                            sb.Append($"WHERE {condition} ");
                            IQueryState<SerialFilterProperties>.CurrentState = QueryStates.HasWhereCondition;

                            return sb;
                        }
                }
            }
            return sb;
        }
    }
}
