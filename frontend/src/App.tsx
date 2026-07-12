import { useEffect, useState } from 'react'
import './App.css'
import Plants from './components/Plants';

function App() {

  const navOptions = ["Home", "Plants", "Settings"];
  const [selectedNav, setSelectedNav] = useState<string>("Home");


  return (
    <div id='app' className='w-full h-screen flex bg-[url(/fishies2highres.png)] bg-cover'>

      <div id='left' className='px-12 flex items-center justify-center bg-slate-700/30 backdrop-blur-md'>
        <div id='menu-bar' className='bg-slate-950/30 backdrop-blur-md rounded-full flex flex-col items-center p-2'>
          {
            navOptions.map(option => {
              return <div key={option} onClick={() => { setSelectedNav(option) }} className={`w-12 h-12 my-1 rounded-full ${selectedNav == option ? "bg-white/70" : "bg-white/30"}`}></div>
            })
          }
        </div>
      </div>

      <div id='right' className='flex-1 flex items-center justify-center'>
        <div id='main-section' className='bg-slate-700/30 backdrop-blur-md flex w-7/8 h-7/8 rounded-3xl p-3'>
          <div id='left' className='w-2/3 rounded-tl-2xl rounded-bl-2xl h-full bg-red-100/20'>
            {
              selectedNav == "Plants" && <Plants />
            }
          </div>
          <div id='right' className='flex-1 pl-3'>
            <div id='box-container' className='flex w-full gap-5 justify-between'>
              <div className='flex-1 h-20 rounded-lg bg-red-400'></div>
              <div className='flex-1 h-20 rounded-lg bg-red-400'></div>
              <div className='flex-1 h-20 rounded-lg bg-red-400'></div>
              <div className='flex-1 h-20 rounded-lg bg-red-400'></div>
            </div>
          </div>
        </div>
      </div>

    </div>
  )
}

export default App
