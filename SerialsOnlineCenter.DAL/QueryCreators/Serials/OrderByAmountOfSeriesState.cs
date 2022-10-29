using SerialsOnlineCenter.DAL.FilterProperties;
using System.Text;

namespace SerialsOnlineCenter.DAL.QueryCreators.Serials
{
    public class OrderByAmountOfSeriesState : IQueryState<SerialFilterProperties>
    {
        public StringBuilder Handle(StringBuilder sb, SerialFilterProperties properties)
        {
            switch (IQueryState<SerialFilterProperties>.CurrentState)
            {
                case QueryStates.HasOrderByCondition:
                    {
                        sb.Append(properties?.OderByAmountOfSeriesDesc == true
                            ? ", amount_of_series DESC "
                            : ", amount_of_series ");

                        return sb;
                    }
                case QueryStates.Initial:
                case QueryStates.HasWhereCondition:
                    {
                        sb.Append(properties?.OderByAmountOfSeriesDesc == true
                            ? "ORDER BY amount_of_series DESC "
                            : "ORDER BY amount_of_series ");

                        IQueryState<SerialFilterProperties>.CurrentState = QueryStates.HasOrderByCondition;

                        return sb;
                    }
            }

            return sb;
        }
    }
}
