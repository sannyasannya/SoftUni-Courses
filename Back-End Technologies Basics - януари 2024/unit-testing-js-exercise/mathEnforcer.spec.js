import { mathEnforcer } from './mathEnforcer.js';
import { expect } from 'chai';

describe('mathEnforcer', () =>{
    describe('addFive', () => {
        it('should return undefined when pass string as input', () => {
            // Arrange
            const stringInput = "someString";

            // Act
            const result = mathEnforcer.addFive(stringInput);

            // Assert
            expect(result).to.be.undefined;
        });

        it('should return undefined when pass undefined as input', () => {
            // Arrange
            const undefinedInput = undefined;

            // Act
            const undefinedResult = mathEnforcer.addFive(undefinedInput);

            // Assert
            expect(undefinedResult).to.be.undefined;
        });

        it('should return undefined when pass number as string as input', () => {
            // Arrange
            const stringInput = "5";

            // Act
            const result = mathEnforcer.addFive(stringInput);

            // Assert
            expect(result).to.be.undefined;
        });

        it('should return correct result when pass floating number as input assert with closeTo()', () => {
            // Arrange
            const floatingNumberInput = 1.01;

            // Act
            const correctResult = mathEnforcer.addFive(floatingNumberInput);

            // Assert
            expect(correctResult).to.be.closeTo(6.01, 0.01);
        });

        it('should return correct result when pass floating number as input and assert with equal', () => {
            // Arrange
            const floatingNumberInput = 1.01;

            // Act
            const correctResult = mathEnforcer.addFive(floatingNumberInput);

            // Assert
            expect(correctResult).to.be.equal(6.01);
        });

        it('should return correct result when pass floating number with a lot of digits as input and assert with closeTo()', () => {
            // Arrange
            const floatingNumberInput = 1.0000001;

            // Act
            const correctResult = mathEnforcer.addFive(floatingNumberInput);

            // Assert
            expect(correctResult).to.be.closeTo(6.01, 0.01);
        });

        it('should return correct result when pass number', () => {
            // Arrange
            const numberInput = 1;

            // Act
            const correctResult = mathEnforcer.addFive(numberInput);

            // Assert
            expect(correctResult).to.equals(6);
        });

        it('should return correct result when pass negative number', () => {
            // Arrange
            const negativeNumber = -15;

            // Act
            const correctResult = mathEnforcer.addFive(negativeNumber);

            // Assert
            expect(correctResult).to.equals(-10);
        });       

       
    });

    describe('subtractTen', () => {
        it('should return undefined when pass string as input', () => {
            // Arrange
            const stringInput = "someString";

            // Act
            const result = mathEnforcer.subtractTen(stringInput);

            // Assert
            expect(result).to.be.undefined;
        });
        

        it('should return undefined when pass number as string as input', () => {
            // Arrange
            const stringInput = "5";

            // Act
            const result = mathEnforcer.subtractTen(stringInput);

            // Assert
            expect(result).to.be.undefined;
        });

        it('should return correct result when pass floating number as input assert with closeTo()', () => {
            // Arrange
            const floatingNumberInput = 1.01;

            // Act
            const correctResult = mathEnforcer.subtractTen(floatingNumberInput);

            // Assert
            expect(correctResult).to.be.closeTo(-8.99, 0.01);
        });

        it('should return correct result when pass floating number as input and assert with equal', () => {
            // Arrange
            const floatingNumberInput = 1.01;

            // Act
            const correctResult = mathEnforcer.subtractTen(floatingNumberInput);

            // Assert
            expect(correctResult).to.be.equal(-8.99);
        });

        it('should return correct result when pass floating number with a lot of digits as input and assert with closeTo()', () => {
            // Arrange
            const floatingNumberInput = 1.0000001;

            // Act
            const correctResult = mathEnforcer.subtractTen(floatingNumberInput);

            // Assert
            expect(correctResult).to.be.closeTo(-8.99, 0.01);
        });

        it('should return correct result when pass number', () => {
            // Arrange
            const numberInput = 5;

            // Act
            const correctResult = mathEnforcer.subtractTen(numberInput);

            // Assert
            expect(correctResult).to.equals(-5);
        });

        it('should return correct result when pass negative number', () => {
            // Arrange
            const negativeNumber = -20;

            // Act
            const correctResult = mathEnforcer.subtractTen(negativeNumber);

            // Assert
            expect(correctResult).to.equals(-30);
        });

        it('should return undefined when pass undefined as input', () => {
            // Arrange
            const undefinedInput = undefined;

            // Act
            const undefinedResult = mathEnforcer.subtractTen(undefinedInput);

            // Assert
            expect(undefinedResult).to.be.undefined;
        });

        
    });

    describe('sum', () => {
        it('should return undefined when Param1: incorrect and Param2: correct', () => {
            // Arrange
            const incorrectFirstParam = "string";
            const correctSecondParam = 12;

            // Act
            const undefinedResult = mathEnforcer.sum(incorrectFirstParam, correctSecondParam);

            // Assert
            expect(undefinedResult).to.be.undefined;
        });

        it('should return undefined when Param1: incorrect and Param2: correct', () => {
            // Arrange
            const correctFirstParam = 5;
            const inorrectSecondParam = "string";

            // Act
            const undefinedResult = mathEnforcer.sum(correctFirstParam, inorrectSecondParam);

            // Assert
            expect(undefinedResult).to.be.undefined;
        });

        it('should return undefined when Param1: incorrect and Param2: incorrect', () => {
            // Arrange
            const incorrectFirstParam = "str";
            const inorrectSecondParam = "string";

            // Act
            const undefinedResult = mathEnforcer.sum(incorrectFirstParam, inorrectSecondParam);

            // Assert
            expect(undefinedResult).to.be.undefined;
        });

        it('should return undefined when Param1: number as string and Param2: correct', () => {
            // Arrange
            const stringFirstParam = '10';
            const correctSecondParam = 12;

            // Act
            const undefinedResult = mathEnforcer.sum(stringFirstParam, correctSecondParam);

            // Assert
            expect(undefinedResult).to.be.undefined;
        });

        it("should return undefined when Param1: correct number and Param2: string", ()=>
        {
            //Arrange
            const numberAsStringFirstParam = 5;
            const correctSecondParam = '5';
            //Act
            const undefinedResults = mathEnforcer.sum(numberAsStringFirstParam, correctSecondParam);
            //Assert
            expect(undefinedResults).to.be.undefined;
        })

        it('should return correct result when Param1: correct and Param2: correct', () => {
            // Arrange
            const correctFirstParam = 2;
            const correctSecondParam = 12;

            // Act
            const correctResult = mathEnforcer.sum(correctFirstParam, correctSecondParam);

            // Assert
            expect(correctResult).to.be.equal(14);
        });

        it('should return correct result when Param1: negative number and Param2: negative number', () => {
            // Arrange
            const firstNumber = -2;
            const secondNumber = -3;

            // Act
            const result = mathEnforcer.sum(firstNumber, secondNumber);

            // Assert
            expect(result).to.be.equal(-5);
        });

        it("should return correct result when Param1: negative number as string and Param2: positive number", ()=>
        {
            //Arrange
            const correctFirstParam = -5;
            const correctSecondParam = 5;
            //Act
            const correctResult = mathEnforcer.sum(correctFirstParam, correctSecondParam);
            //Assert
            expect(correctResult).to.be.equal(0);
        })

        it('should return correct result when Param1: floating number and Param2: positive number', () => {
            // Arrange
            const firstNumber = 5.01;
            const secondNumber = 5;

            // Act
            const result = mathEnforcer.sum(firstNumber, secondNumber);

            // Assert
            expect(result).to.be.equal(10.01);            
        });

        it("should return correct result when Param1: floating number as string and Param2: positive number with closeTo assertion", ()=>
        {
            //Arrange
            const floattingNumberFirstParam = 5.00001;
            const correctSecondParam = 5;
            //Act
            const correctResult = mathEnforcer.sum(floattingNumberFirstParam, correctSecondParam);
            //Assert
            expect(correctResult).to.be.closeTo(10.01, 0.01);
        });

        it("should return correct result when Param1: floating number as string and Param2: negative number with closeTo assertion", ()=>
        {
            //Arrange
            const floatingNumberFirstParam = 5.01;
            const floatingSecondParam = 5.01;
            //Act
            const correctResult = mathEnforcer.sum(floatingNumberFirstParam, floatingSecondParam);
            //Assert
            expect(correctResult).to.be.closeTo(10.02, 0.01);
        });
        
        it("should return correct result when Param1: zero number and Param2: floating number with closeTo assertion", ()=>
        {
            //Arrange
            const zeroNumberFirstParam = 0;
            const secondParam = 0.1;
            //Act
            const correctResult = mathEnforcer.sum(zeroNumberFirstParam, secondParam);
            //Assert
            expect(correctResult).to.be.closeTo(0.1, 0.01);
        });       

    });
});