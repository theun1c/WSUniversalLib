using Xunit;

namespace WSUniversalLib.Tests
{
    public class WSUniversalLibTests
    {
        // ===== ПРОСТЫЕ ТЕСТЫ (10 штук) =====

        [Fact]
        [Trait("Category", "Simple")]
        public void GetQuantityForProduct_ValidInput_ProductType1_ReturnsCorrectValue()
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
            Assert.Equal(83, result);
        }

        [Fact]
        [Trait("Category", "Simple")]
        public void GetQuantityForProduct_ValidInput_ProductType2_ReturnsCorrectValue()
        {
            // Arrange
            var calculation = new Calculation();
            int productType = 2;
            int materialType = 1;
            int count = 5;
            float width = 1.5f;
            float length = 2.0f;

            // Act
            int result = calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.Equal(38, result); 
        }

        [Fact]
        [Trait("Category", "Simple")]
        public void GetQuantityForProduct_ValidInput_ProductType3_ReturnsCorrectValue()
        {
            // Arrange
            var calculation = new Calculation();
            int productType = 3;
            int materialType = 1;
            int count = 2;
            float width = 1.0f;
            float length = 1.0f;

            // Act
            int result = calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.Equal(17, result); 
        }

        [Fact]
        [Trait("Category", "Simple")]
        public void GetQuantityForProduct_ValidInput_MaterialType2_ReturnsCorrectValue()
        {
            // Arrange
            var calculation = new Calculation();
            int productType = 1;
            int materialType = 2;
            int count = 10;
            float width = 2.0f;
            float length = 2.0f;

            // Act
            int result = calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.Equal(44, result); 
        }

        [Fact]
        [Trait("Category", "Simple")]
        public void GetQuantityForProduct_CountEqualsOne_ReturnsCorrectValue()
        {
            // Arrange
            var calculation = new Calculation();
            int productType = 1;
            int materialType = 1;
            int count = 1;
            float width = 1.0f;
            float length = 1.0f;

            // Act
            int result = calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        [Trait("Category", "Simple")]
        public void GetQuantityForProduct_ZeroCount_ReturnsMinusOne()
        {
            // Arrange
            var calculation = new Calculation();
            int productType = 1;
            int materialType = 1;
            int count = 0;
            float width = 2.5f;
            float length = 3.0f;

            // Act
            int result = calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        [Trait("Category", "Simple")]
        public void GetQuantityForProduct_ZeroWidth_ReturnsMinusOne()
        {
            // Arrange
            var calculation = new Calculation();
            int productType = 1;
            int materialType = 1;
            int count = 10;
            float width = 0;
            float length = 3.0f;

            // Act
            int result = calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        [Trait("Category", "Simple")]
        public void GetQuantityForProduct_ZeroLength_ReturnsMinusOne()
        {
            // Arrange
            var calculation = new Calculation();
            int productType = 1;
            int materialType = 1;
            int count = 10;
            float width = 2.5f;
            float length = 0;

            // Act
            int result = calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        [Trait("Category", "Simple")]
        public void GetQuantityForProduct_InvalidProductType_ReturnsMinusOne()
        {
            // Arrange
            var calculation = new Calculation();
            int productType = 5;
            int materialType = 1;
            int count = 10;
            float width = 2.5f;
            float length = 3.0f;

            // Act
            int result = calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        [Trait("Category", "Simple")]
        public void GetQuantityForProduct_InvalidMaterialType_ReturnsMinusOne()
        {
            // Arrange
            var calculation = new Calculation();
            int productType = 1;
            int materialType = 5;
            int count = 10;
            float width = 2.5f;
            float length = 3.0f;

            // Act
            int result = calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.Equal(-1, result);
        }

        // ===== СЛОЖНЫЕ ТЕСТЫ (5 штук) =====

        [Fact]
        [Trait("Category", "Complex")]
        public void GetQuantityForProduct_LargeValues_ReturnsCorrectValue()
        {
            // Arrange
            var calculation = new Calculation();
            int productType = 3;
            int materialType = 2;
            int count = 1000;
            float width = 100.5f;
            float length = 200.3f;

            // Act
            int result = calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.True(result > 0);
            // Проверяем, что результат в разумных пределах
            Assert.InRange(result, 169000000, 170000000);
        }

        [Fact]
        [Trait("Category", "Complex")]
        public void GetQuantityForProduct_FractionalDimensions_ReturnsCorrectValue()
        {
            // Arrange
            var calculation = new Calculation();
            int productType = 2;
            int materialType = 1;
            int count = 7;
            float width = 2.33f;
            float length = 3.67f;

            // Act
            int result = calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.Equal(150, result);
        }

        [Fact]
        [Trait("Category", "Complex")]
        public void GetQuantityForProduct_AllCombinations_ReturnsPositiveValue()
        {
            // Arrange
            var calculation = new Calculation();

            // Проверяем все комбинации типов продуктов и материалов
            for (int productType = 1; productType <= 3; productType++)
            {
                for (int materialType = 1; materialType <= 2; materialType++)
                {
                    // Act
                    int result = calculation.GetQuantityForProduct(productType, materialType, 5, 2.0f, 3.0f);

                    // Assert
                    Assert.True(result > 0, $"Failed for productType={productType}, materialType={materialType}");
                }
            }
        }

        [Fact]
        [Trait("Category", "Complex")]
        public void GetQuantityForProduct_ExtremelySmallDimensions_ReturnsCorrectValue()
        {
            // Arrange
            var calculation = new Calculation();
            int productType = 1;
            int materialType = 1;
            int count = 1000000;
            float width = 0.001f;
            float length = 0.001f;

            // Act
            int result = calculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.Equal(1, result); 
        }

        [Fact]
        [Trait("Category", "Complex")]
        public void GetQuantityForProduct_MaxIntValues_NoOverflowException()
        {
            // Arrange
            var calculation = new Calculation();
            int productType = 3;
            int materialType = 2;
            int count = int.MaxValue / 1000000; 
            float width = 1000f;
            float length = 1000f;

            // Act & Assert
            var exception = Record.Exception(() =>
                calculation.GetQuantityForProduct(productType, materialType, count, width, length));

            Assert.Null(exception); 
        }
    }
}