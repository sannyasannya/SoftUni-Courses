import { analyzeArray } from './arrayAnalyzer.js';
import { expect } from 'chai';

describe('analyzeArray', () => {
    it('should return undefined when pass non-array as input', () => {
        // Arrange
        const nonArrayInput = "someString";

        // Act
        const result = analyzeArray(nonArrayInput);
        
        // Assert
        expect(result).to.be.undefined;
    });

    it('should return undefined when pass empty array as input', () => {
        // Arrange
        const emptyArrayInput = [];

        // Act
        const result = analyzeArray(emptyArrayInput);
        
        // Assert
        expect(result).to.be.undefined;
    });

    it('should return correct value when pass array with different numbers as input', () => {
        // Arrange
        const arrayInput = [1, 2, 3, -5, 6];

        // Act
        const result = analyzeArray(arrayInput);
        
        // Assert
        expect(result).to.deep.equal({min: -5, max: 6, length:5 });
    });

    it('should return correct value when pass array with single element as input', () => {
        // Arrange
        const arrayInput = [3];

        // Act
        const result = analyzeArray(arrayInput);
        
        // Assert
        expect(result).to.deep.equal({min: 3, max: 3, length: 1 });
    });

    it('should return correct value when pass array with same elements as input', () => {
        // Arrange
        const arrayInput = [3, 3, 3];

        // Act
        const result = analyzeArray(arrayInput);
        
        // Assert
        expect(result).to.deep.equal({min: 3, max: 3, length: 3 });
    });
});