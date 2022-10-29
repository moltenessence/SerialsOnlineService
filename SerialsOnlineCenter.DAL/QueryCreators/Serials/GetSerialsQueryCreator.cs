using SerialsOnlineCenter.DAL.FilterProperties;
using System.Text;

namespace SerialsOnlineCenter.DAL.QueryCreators.Serials
{
    public class GetSerialsQueryCreator
    {
        private readonly SerialFilterProperties? _filterProperties;
        public GetSerialsQueryCreator(SerialFilterProperties filterProperties)
        {
            _filterProperties = filterProperties;
        }

        public string Query()
        {
            StringBuilder sb = new StringBuilder("SELECT * FROM serials ");

            var whereCondition = false;

            if (!String.IsNullOrEmpty(_filterProperties?.Name))
            {
                sb.Append("WHERE name LIKE @SerialName ");
                whereCondition = true;
            }

            if (_filterProperties?.AmountOfSeries > 0)
            {
                if (whereCondition)
                {
                    sb.Append("AND amount_of_series > @AmountOfSeries ");
                }
                else
                {
                    sb.Append("WHERE amount_of_series > @AmountOfSeries ");
                    whereCondition = true;
                }
            }

            if (_filterProperties?.ReleaseYear > 0)
            {
                if (whereCondition)
                {
                    sb.Append("AND release_year > @ReleaseYear ");
                }
                else
                {
                    sb.Append("WHERE release_year > @ReleaseYear ");
                    whereCondition = true;
                }
            }

            if (_filterProperties?.OderByAmountOfSeriesDesc == true)
            {
                sb.Append("ORDER BY amount_of_series DESC ");
            }
            else
            {
                sb.Append("ORDER BY amount_of_series ");
            }

            if (_filterProperties?.OrderByReleaseDesc == true)
            {
                sb.Append(", release_year DESC ");
            }
            else
            {
                sb.Append(", release_year ");
            }

            return sb.ToString();
        }
    }
}
