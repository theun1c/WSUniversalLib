using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Calculation
    {
        // coeff
        private float _1stPrTypeCoeff = 1.1F;
        private float _2ndPrTypeCoeff = 2.5F;
        private float _3rdPrTypeCoeff = 8.43F;

        // defect percent for material 
        private float _1stMaterialDefect = 0.3F;
        private float _2ndMaterialDefect = 0.12F;

        // func for math count
        public int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
            // ROUND ( count * productType * (width *  length) / (1 - materialType / 100) )

            // use one more constants
            float typeCoef = 0.0F;
            float materialDefect = 0.0F;

            if ((productType > 0 && productType < 4) && (materialType > 0 && materialType < 3) && (count > 0 && width > 0 && length > 0))
            {
                // for pr type 
                switch (productType)
                {
                    case 1:
                        typeCoef = _1stPrTypeCoeff;
                        break;
                    case 2:
                        typeCoef = _2ndPrTypeCoeff;
                        break;
                    case 3:
                        typeCoef = _3rdPrTypeCoeff;
                        break;                        
                }

                // for materials
                switch (materialType)
                {
                    case 1:
                        materialDefect = _1stMaterialDefect;
                        break;
                    case 2:
                        materialDefect = _2ndMaterialDefect;
                        break;
                }

                // return val
                return (int)Math.Round((double)((count * typeCoef * width * length) / (1 - (materialDefect / 100))));  
            }
            else
            {
                // also retern bun like an error
                return -1; 
            }
        }
    }
}
