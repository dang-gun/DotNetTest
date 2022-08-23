import React, { Component } from 'react';
import parse from 'html-react-parser'

//import GlobalStatic from '../Global/GlobalStatic.js'
//import GlobalStatic from '@/Global/GlobalStatic'
import GlobalStatic from '../../src/pages/globalstatic.js'
//import GlobalStatic from 'src/Global/GlobalStatic.js'
//import Test from 'Test1/test/App.js'

export class Home extends Component 
{
    

    static displayName = Home.name;

    sDisplayName = Home.name;

    

    sTest1 = '<button onClick={TestCall}>버튼 이벤트 호출({TestText})</button>';
    sTest2 = '<div><button onclick="alert(\'hello\')">JS 함수</button><button onclick="{TestCall}">리액트 함수</button></div>';
    //
    sTest3 = '<div><button onclick="alert(\'hello\')">JS 함수</button><button onclick="{TestCall}">리액트 함수</button>${TestLiterals}</div>';

    reactsTest1 = "";
    reactsTest2 = "";
    reactsTest2_2 = "";
    reactsTest3 = "";

    /** 생성자 */
    constructor()
    {
        super();
        let jsonData = {
            TestText: '테스트 텍스트~',
            TestLiterals: '리터럴 변환',
            TestInt: 124,
            sDisplayName: this.sDisplayName,
        }
        

        this.reactsTest1
            = this.sTest1.replaceReact(jsonData);
        console.log("--- this.reactsTest1  ---");
        console.log(this.reactsTest1);

        this.reactsTest2
            = parse(this.sTest2
                , {
                    replace: domNode =>
                    {
                        if (domNode.name === 'button')
                        {//버튼 이벤트 처리
                            let temp = domNode.attribs.onclick;

                            delete domNode.attribs.onclick;

                            return (
                                <button
                                    {...domNode.attribs}
                                    onClick={() => { Function('"use strict";return (' + temp + ')')(); }}
                                >{domNode.children[0].data}</button>
                            );
                        }
                    }
                });

        console.log("this.reactsTest2 : ");
        console.log(this.reactsTest2);


        this.reactsTest2_2
            = parse(this.sTest2
                , {
                    replace: domNode =>
                    {
                        if (domNode.name === 'button')
                        {
                            console.log(domNode);
                            let temp = domNode.attribs.onclick;
                            //기본 빈 함수
                            let funcCall = function (event, param) { };

                            //기존 로드의 클릭이벤트 제거
                            delete domNode.attribs.onclick;

                            if ("{" === temp.substring(0, 1)
                                && "}" === temp.substring(temp.length - 1))
                            {//앞뒤로 있는게 중괄호다 = 리액트 함수

                                //리액트 함수로 취급한다.
                                temp = temp.split(/{|}/g)[1];
                                funcCall = this[temp];
                            }
                            else
                            {//자바스크립트
                                funcCall = function (event, param)
                                {
                                    Function('"use strict";return (' + temp + ')')(event, param);
                                };
                            }

                            return (
                                <button
                                    {...domNode.attribs}
                                    onClick=
                                    {(event, param) =>
                                    {
                                        funcCall(event, param);
                                    }}
                                >{domNode.children[0].data}</button>
                            );
                        }
                    }
                });
        console.log("this.reactsTest2_2 : ");
        console.log(this.reactsTest2_2);





        this.reactsTest3 = this.sTest3.interpolate(jsonData);
        console.log("this.reactsTest3 -interpolate : " + this.reactsTest3);
        this.reactsTest3 = this.reactsTest3.replaceReact(jsonData);
        console.log("this.reactsTest3 -replaceReact : " + this.reactsTest3);

        this.reactsTest3
            = parse(this.reactsTest3
                , {
                    replace: domNode =>
                    {
                        if (domNode.name === 'button')
                        {
                            console.log(domNode);
                            let temp = domNode.attribs.onclick;
                            //기본 빈 함수
                            let funcCall = function (event, param) { };

                            delete domNode.attribs.onclick;

                            if ("{" === temp.substring(0, 1)
                                && "}" === temp.substring(temp.length - 1))
                            {//앞뒤로 있는게 중괄호다

                                //리액트 함수로 취급한다.
                                temp = temp.split(/{|}/g)[1];
                                funcCall = this[temp];
                            }
                            else
                            {
                                funcCall = function (event, param)
                                {
                                    Function('"use strict";return (' + temp + ')')(event, param);
                                };
                            }
                            
                            //domNode.attribs.onClick
                            //    = domNode.attribs.onclick;
                            return (
                                <button
                                    {...domNode.attribs}
                                    onClick=
                                    {(event, param) =>
                                    {
                                        funcCall(event, param);
                                    }}
                                >{domNode.children[0].data}</button>
                            );
                        }
                    }
                });

        console.log(" --- this.reactsTest3 --- "); 
        console.log(this.reactsTest3);
    }

    async TestCall(event, param)
    {
        
        alert("'TestCall'에서 호출됨?");
        const response = await fetch('weatherforecast');
        //const response = await fetch('https://localhost:7044/api/SuccessCall');
        //const response = await fetch('/api/SuccessCall');
        const data = await response.json();
        console.log(data);
    }


    
    render()
    {
        return (
            <div>
                <h1>Hello, world! {this.sDisplayName}</h1>
                <p>Welcome to your new single-page application, built with:</p>
                <ul>
                    <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
                    <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
                    <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
                </ul>
                <p>To help you get started, we have also set up:</p>
                <ul>
                    <li><strong>Client-side navigation</strong>. For example, click <em>Counter</em> then <em>Back</em> to return here.</li>
                    <li><strong>Development server integration</strong>. In development mode, the development server from <code>create-react-app</code> runs in the background automatically, so your client-side resources are dynamically built on demand and the page refreshes when you modify any file.</li>
                    <li><strong>Efficient production builds</strong>. In production mode, development-time features are disabled, and your <code>dotnet publish</code> configuration produces minified, efficiently bundled JavaScript files.</li>
                </ul>
                <p>The <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm test</code> or <code>npm install</code>.</p>

                html 직접 출력
                <br />
                <button onClick={this.TestCall}>백엔드 호출 1</button>
                <br />
                <br />
                sTest1 변수 출력
                <br />
                {this.sTest1}
                <br />
                <br />
                sTest1 : dangerouslySetInnerHTML로 출력
                <div dangerouslySetInnerHTML={{ __html: this.sTest1 }}></div>
                <br />
                <br />
                sTest1 -> reactsTest1(리액트 변수 변환 후) : dangerouslySetInnerHTML로 출력
                <br />
                <div dangerouslySetInnerHTML={{ __html: this.reactsTest1 }}></div>
                <br />
                <br />
                onClick 변환 : 자바스크립트만 변환
                <br />
                {this.reactsTest2}
                <br />
                <br />
                onClick 변환 : 리액트 함수도 변환
                <br />
                {this.reactsTest2_2}
                <br />
                <br />
                리터럴, 리액트 변수, 리액트 이벤트 처리
                <br />
                {this.reactsTest3}
                <br />
                <br />
                {this.dd}
            </div>
        );
    }
}



/**
 * 문자열을 리러털로 변환
 * https://stackoverflow.com/a/41015840/6725889
 * @param {json} params 데이터로 사용할 json
 */
String.prototype.interpolate = function (params)
{
    const names = Object.keys(params);
    const vals = Object.values(params);
    return new Function(...names, `return \`${this}\`;`)(...vals);
}

/**
 * 문자열에서 리액트 문법의 변수를 찾아 변환하여 리턴한다.
 * @param {any} jsonParams 찾을 변수명: 데이터
 */
String.prototype.replaceReact = function (jsonParams)
{
    let sReturn = this;

    let r = sReturn.match(/\{[\w]+\}/g);
    r && r.forEach((state) =>
    {
        let regex = new RegExp(state, 'g');
        let stateItem = state.split(/{|}/g)[1];
        let objTarget = jsonParams[stateItem];
        if (objTarget)
        {//대상이 있다.
            sReturn = sReturn.replace(regex, objTarget);
        }
        //대상이 아니면 그냥 둔다.
    });

    return sReturn;
}