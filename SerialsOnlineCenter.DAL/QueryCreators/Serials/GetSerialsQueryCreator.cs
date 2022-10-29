using SerialsOnlineCenter.DAL.FilterProperties;
using SerialsOnlineCenter.DAL.Interfaces.QueryCreators;
using System.Text;

namespace SerialsOnlineCenter.DAL.QueryCreators.Serials
{
    public class GetSerialsQueryCreator : IQueryCreator
    {
        private readonly SerialFilterProperties? _filterProperties;
        private StringBuilder _sb;

        public GetSerialsQueryCreator(SerialFilterProperties filterProperties)
        {
            _filterProperties = filterProperties;
            _sb = new StringBuilder();
        }

        public string Query() => Initialize().
            FindByName().
            FindByReleaseYear().
            FindByAmountOfSeries().
            OrderByAmountOfSeries().
            OrderByReleaseYear().
            _sb.ToString();

        private GetSerialsQueryCreator Initialize()
        {
            _sb = new InitialState().Handle(_sb, _filterProperties);

            return this;
        }

        private GetSerialsQueryCreator FindByName()
        {
            _sb = new FindByNameState().Handle(_sb, _filterProperties);

            return this;
        }

        private GetSerialsQueryCreator FindByReleaseYear()
        {
            _sb = new FindByReleaseYearState().Handle(_sb, _filterProperties);

            return this;
        }

        private GetSerialsQueryCreator FindByAmountOfSeries()
        {
            _sb = new FindByAmountOfSeriesState().Handle(_sb, _filterProperties);

            return this;
        }


        private GetSerialsQueryCreator OrderByAmountOfSeries()
        {
            _sb = new OrderByAmountOfSeriesState().Handle(_sb, _filterProperties);

            return this;
        }

        private GetSerialsQueryCreator OrderByReleaseYear()
        {
            _sb = new OrderByReleaseYearState().Handle(_sb, _filterProperties);

            return this;
        }
    }
}
