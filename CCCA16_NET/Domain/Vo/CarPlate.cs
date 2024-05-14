using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace CCCA16_NET.Domain.Vo
{
    public class CarPlate
    {
        private string Value { get; set; }

        public CarPlate(string carPlate)
        {
            if (!string.IsNullOrEmpty(carPlate)
                && Regex.IsMatch(carPlate, "^(?:[a-zA-Z][a-zA-Z-][a-zA-Z]|[0-9]{4})$")) throw new Exception("Invalid car plate");
            this.Value = carPlate;
        }

        public string GetValue()
        {
            return this.Value;
        }
    }
}
