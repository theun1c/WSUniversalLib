namespace WSUniversalLib.Tests
{
    public class WSUniversalLibTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var calculation = new Calculation();
            int productType = 1;
            int materialType = 1;
            int count = 10;
            float width = 2.5f;
            float length = 3.0f;

            // Act
            int result = calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            // Ожидаемый результат: count * typeCoef * (width * length) / (1 - materialDefect/100)
            // = 10 * 1.1 * (2.5 * 3.0) / (1 - 0.3/100)
            // = 10 * 1.1 * 7.5 / 0.997 ≈ 82.75 → округляем до 83
            Assert.Equal(83, result);
        }
    }
}
