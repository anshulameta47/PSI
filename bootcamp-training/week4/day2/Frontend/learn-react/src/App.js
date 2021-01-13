import React from 'react';
import logo from './logo.svg';
import './App.css';
import {Userform} from './userform/userform'
function App() {//component
  return ( //JSX
    <div className="App">
      <header className="App-header">
        <Userform></Userform>
      </header>
    </div>
  );
}

export default App;
