using SerialsOnlineCenter.DAL.FilterProperties;
using System.Text;

namespace SerialsOnlineCenter.DAL.QueryCreators.Serials
{
    public class FindByNameState : IQueryState<SerialFilterProperties>
    {
        private const string condition = "name LIKE @SerialName";
        public StringBuilder Handle(StringBuilder sb, SerialFilterProperties properties)
        {
            if (!String.IsNullOrEmpty(properties?.Name))
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

