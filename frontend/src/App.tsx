import { useEffect, useState } from 'react'
import './App.css'
import Plants from './components/Plants';
import Home from './components/Home';

function App() {

  const navOptions = ["Home", "Plants", "Settings"];
  const [selectedNav, setSelectedNav] = useState<string>("Home");

  return (
    <div id='app' className='w-full h-screen flex bg-[url(/fishies2highres.png)] bg-cover'>

      <div id='left-spacer' className='w-50 flex items-center justify-center'>
        <div id='ios-style-wrapper' className='p-0.5 bg-gradient-to-b from-slate-100/70 via-slate-950/30 to-slate-200/60 rounded-full'>
          <div id='menu-bar' className='bg-slate-950/30 backdrop-blur-md rounded-full flex flex-col items-center p-2'>
            {
              navOptions.map(option => {
                return <div key={option} onClick={() => { setSelectedNav(option) }} className={`cursor-pointer w-12 shadow-md h-12 my-1 rounded-full ${selectedNav == option ? "bg-slate-100/50" : "bg-slate-200/10"}`}></div>
              })
            }
          </div>
        </div>
      </div>

      <div id='middle' className='flex-1 flex items-center justify-center'>
        <div id='ios-style-wrapper' className='p-0.5 bg-gradient-to-b from-slate-100/20 via-slate-950/40 to-slate-200/10 rounded-3xl w-7/8 h-6/8 shadow-lg'>
          <div id='main-section' className='bg-slate-200/20 backdrop-blur-md flex rounded-3xl h-full'>
            {
              selectedNav == "Plants" && <Plants />
            }
            {
              selectedNav == "Home" && <Home />
            }
          </div>
        </div>
      </div>

      <div id='right-spacer' className='w-50'></div>

    </div>
  )
}

export default App
