namespace SWOP.Transport.Models
{
    public class Policeman : Employee
    {
        public Grade Grade { get; set; }

        public override decimal Calculate() => base.Calculate() + 100;

        //public new decimal Calculate()
        //{
        //    return 100;
        //}
    }

    public enum Grade
    {
        Posterunkowy,
        Sierzant,
        StarszySierzant,
        Aspirant,
        Komisarz,
        Inspektor
    }
}
