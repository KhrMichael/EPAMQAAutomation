namespace ObjectOrientedDesignPrinciplesTaskTest.Doubles;

public static class Doubles
{
   public static double ToNumberWithTwoDecimalPlaces(this double number) =>
      (uint) number + ((int) ((number - (uint) number) * 100)) / 100.0;
}