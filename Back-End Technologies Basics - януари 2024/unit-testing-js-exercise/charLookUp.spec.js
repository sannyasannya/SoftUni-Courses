import { lookupChar } from './charLookUp.js';
import { expect } from 'chai';

describe('lookupChar', () => {
    it('should return indefined when first parameter is from incorrect and second parameter is correct type', () => {
        // Arrange
        const incorrectFirstParam = 123;
        const correctSecondParam = 1;

        //Act
        const undefinedResult = lookupChar(incorrectFirstParam, correctSecondParam); 

        // Assert
        expect(undefinedResult).to.be.undefined;
    });

    it('should return indefined when first parameter is from correct and second parameter is incorrect type', () => {
        // Arrange
        const correctFirstParam = "hello";
        const incorrectSecondParam = "10";

        //Act  
        const undefinedResult = lookupChar(correctFirstParam, incorrectSecondParam);   

        // Assert
        expect(undefinedResult).to.be.undefined;

    });

    it('should return indefined when first parameter is from correct and second parameter is incorrect float type', () => {
        // Arrange
        const correctFirstParam = "hello";
        const incorrectFloatNumberSecondParam = 10.2;

        //Act  
        const undefinedResult = lookupChar(correctFirstParam, incorrectFloatNumberSecondParam);   

        // Assert
        expect(undefinedResult).to.be.undefined;

    });

    it('should return Incorrect Index when first parameter is from correct and second parameter is bigger than string length', () => {
        // Arrange
        const correctFirstParam = "hello";
        const biggerLengthSecondParam = 10;

        //Act  
        const incorrectResult = lookupChar(correctFirstParam, biggerLengthSecondParam);   

        // Assert
        expect(incorrectResult).to.equals("Incorrect index");

    });

    it('should return Incorrect Index when first parameter is from correct and second parameter is lower than string length', () => {
        // Arrange
        const correctFirstParam = "hello";
        const lowerLengthSecondParam = -10;

        //Act  
        const incorrectResult = lookupChar(correctFirstParam, lowerLengthSecondParam);   

        // Assert
        expect(incorrectResult).to.equals("Incorrect index");

    });

    it('should return correct when all the parameters are correct', () => {
        // Arrange
        const correctFirstParam = "hello";
        const correctSecondParam = 4;

        //Act  
        const correctResult = lookupChar(correctFirstParam, correctSecondParam);   

        // Assert
        expect(correctResult).to.equals('o');

    });
});