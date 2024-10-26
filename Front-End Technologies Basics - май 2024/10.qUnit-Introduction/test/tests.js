import { add, substract } from "./demo.js";

// function assertAddFunction(assert) {
//     QUnit.assert(add(1, 2), 3);
// }

//QUnit.module('add');

//QUnit.test('two numbers', assertAddFunction);


// QUnit.test('two numbers', function (assert) {
//     assert.equal(add(1, 2), 3);
// });

// QUnit.module('substraction');
// QUnit.test('two numbers', function (assert) {
//     assert.equal(add(1, 2), 3);
// });

QUnit.module('Math operations', {
    beforeEach: function() {
        //execute code before each test
    },
    afterEach: function() {
        //execute code after each test
    }
}, 
function() {
    QUnit.test('Add test', function(assert){
        assert.equal(add(1, 2), 3, '1+2 should be equal to 3');
    });
    QUnit.test('Substraction test', function(assert){
        assert.equal(substract(2, 2), 0, '2-2 should be equal to 0');
    });
    
})


