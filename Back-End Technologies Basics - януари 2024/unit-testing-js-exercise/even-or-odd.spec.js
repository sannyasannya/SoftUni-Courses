import {isOddOrEven} from './even-or-odd.js';
import { expect } from 'chai';

describe('isOddOrEven', () => {
    it('should return undefined when pass non string value is input', () => {
       // Arrange
       const input = 15;
       const inputUndefined = undefined;
       const nullValue = null;
       const floatNumber = 10.10;

       // Act
       const resultNumber = isOddOrEven(input);
       const resultUndefined = isOddOrEven(inputUndefined);
       const resultNull = isOddOrEven(nullValue);
       const resultFloatNum = isOddOrEven(floatNumber); 

       // Assert
       expect(resultNumber).to.be.undefined;
       expect(resultUndefined).to.be.undefined;
       expect(resultNull).to.be.undefined;
       expect(resultFloatNum).to.be.undefined;
    });

    it('should return even value when the input string is even', () => {
        // Assert
        const evenStringLength = '1234';

        // Act
        const result = isOddOrEven(evenStringLength);

        // Assert
        expect(result).to.equals('even');
    });

    it('should return odd value when the input string is odd', () => {
        // Assert
        const oddStringLength = '333';

        // Act
        const result = isOddOrEven(oddStringLength);

        // Assert
        expect(result).to.equals('odd');
    });

    it('should return ... when the input string length is 0', () => {
        // Assert
        const zeroStringLength = "";

        // Act
        const result = isOddOrEven(zeroStringLength);

        // Assert
        expect(result).to.equals('even');
    });
});