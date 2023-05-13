import logo from './logo.svg';
import './App.css';
import React from 'react';
import axios from 'axios';

function App() {
  const [taskNumber1Text, setTaskNumber1Text] = React.useState("saya dapat menyelesaikan soal ini dengan baik");
  const [inputNumber, setInputNumber] = React.useState(0);
  const [resultTaskNumber1, setResultTaskNumber1] = React.useState([]);
  const [result, setResult] = React.useState([]);

  const generateTaskNumber = (e) => {
    axios.get('https://localhost:7200/Generate/TaskNumber1?inputText=' + taskNumber1Text)
    .then((response) => {
      setResultTaskNumber1(response.data);
    });
  };

  const generateTriangle = (e) => {
    axios.get('https://localhost:7200/Generate/Triangle?inputText=' + inputNumber)
    .then((response) => {
      setResult(response.data);
    });
  };

  const generateOddNumbers = (e) => {
    axios.get('https://localhost:7200/Generate/OddNumbers?maxNumber=' + inputNumber)
    .then((response) => {
      setResult(response.data);
    });
  };
  
  const generatePrimeNumbers = (e) => {
    axios.get('https://localhost:7200/Generate/PrimeNumbers?maxNumber=' + inputNumber)
    .then((response) => {
      setResult(response.data);
    });
  };

  return (
    <div className="App">
      <header className="App-header">
        <div>
          <div style={{marginBottom: 50, display: 'block'}}>
            <div>
              <input style={{width:500}} name="TaskNumber1" type="text" value={taskNumber1Text} onChange={(e) => setTaskNumber1Text(e.target.value)} />
            </div>
            <div>
              <button type="button" onClick={generateTaskNumber}>Generate Soal Nomor 1</button>
            </div>
            <div>
              {
                resultTaskNumber1
              }
            </div>
          </div>
          <div>
            <div>
              <input name="InputNumber" type="number" value={inputNumber} onChange={(e) => setInputNumber(e.target.value)} />
            </div>
            <div>
              <button type="button" onClick={generateTriangle}>Generate Segitiga</button>              
            </div>
            <div>
              <button type="button" onClick={generateOddNumbers}>Generate Angka Ganjil</button>
            </div>
            <div>
              <button type="button" onClick={generatePrimeNumbers}>Generate Bilangan Prima</button>
            </div>
            <div>
              {
                result.map((item, i) => {
                  return <div key={i} value={item}>
                      {item}
                  </div>;
                  })
              }
            </div>
          </div>     
        </div>   
      </header>
    </div>
  );
}

export default App;
