using SerialsOnlineCenter.DAL.FilterProperties;
using System.Text;

namespace SerialsOnlineCenter.DAL.QueryCreators.Serials
{
    public class FindByReleaseYearState : IQueryState<SerialFilterProperties>
    {
        private const string condition = "release_year >= @ReleaseYear";
        public StringBuilder Handle(StringBuilder sb, SerialFilterProperties properties)
        {
            if (properties?.ReleaseYear > 0)
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

