using SerialsOnlineCenter.DAL.FilterProperties;
using System.Text;

namespace SerialsOnlineCenter.DAL.QueryCreators.Serials
{
    public class OrderByReleaseYearState : IQueryState<SerialFilterProperties>
    {
        public StringBuilder Handle(StringBuilder sb, SerialFilterProperties properties)
        {
            switch (IQueryState<SerialFilterProperties>.CurrentState)
            {
                case QueryStates.HasOrderByCondition:
                    {
                        sb.Append(properties?.OrderByReleaseDesc == true
                            ? ", release_year DESC "
                            : ", release_year ");

                        return sb;
                    }
                case QueryStates.Initial:
                case QueryStates.HasWhereCondition:
                    {
                        sb.Append(properties?.OrderByReleaseDesc == true
                            ? "ORDER BY release_year DESC "
                            : "ORDER BY release_year ");

                        IQueryState<SerialFilterProperties>.CurrentState = QueryStates.HasOrderByCondition;

                        return sb;
                    }
            }

            return sb;
        }
    }
}
