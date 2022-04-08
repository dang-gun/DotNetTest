import _ from 'lodash';
import Test01 from "/src/Test01.js";

function createChild() 
{
    var element = document.createElement('div');
    let aa = _.join(['Hello', 'Webpack'], ' ');
    aa = aa + " " + Test01.TestStr();
    element.innerHTML = aa;
    return element;
}

document.body.appendChild(createChild());