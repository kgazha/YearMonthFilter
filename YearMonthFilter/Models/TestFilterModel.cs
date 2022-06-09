using Microsoft.AspNetCore.Mvc;

namespace YearMonthFilter.Models
{
    public class TestFilterModel : TestFilter
    {
        private string _yearMonth;

        [FromQuery(Name = "YearMonth")]
        public new string YearMonth
        {
            get
            {
                return _yearMonth;
            }
            set
            {
                _yearMonth = value;

                if (!string.IsNullOrEmpty(_yearMonth))
                {
                    bool parsedMonth = int.TryParse(_yearMonth.Split('.')[0], out int month);
                    bool parsedYear = int.TryParse(_yearMonth.Split('.')[1], out int year);

                    if (!parsedMonth || !parsedYear)
                        return;

                    if (base.YearMonth == null)
                        base.YearMonth = new YearMonth { Month = month, Year = year };
                }
            }
        }
    }
}
