import './App.css'

function App() {

  return (
    <div id='app' className='w-full h-screen flex bg-[url(/fishies2highres.png)] bg-cover'>

      <div id='left' className='px-12 flex items-center justify-center bg-slate-700/30 backdrop-blur-md'>
        <div id='menu-bar' className='w-20 bg-slate-950/30 backdrop-blur-md rounded-full flex flex-col items-center p-2'>
          <div className='w-16 h-16 my-1 rounded-full bg-white/70'></div>
          <div className='w-16 h-16 my-1 rounded-full bg-white/20'></div>
          <div className='w-16 h-16 my-1 rounded-full bg-white/20'></div>
        </div>
      </div>

      <div id='right' className='flex-1 flex items-center justify-center'>
        <div id='main-section' className='bg-slate-700/30 backdrop-blur-md flex w-7/8 h-7/8 rounded-3xl p-3'>
          <div id='left' className='w-2/3 rounded-tl-2xl rounded-bl-2xl h-full bg-red-100/20'></div>
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
