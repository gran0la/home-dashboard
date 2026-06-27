import './App.css'

function App() {

  return (
    <div id='app' className='w-full h-screen flex bg-[url(/fishies2highres.png)] bg-cover'>

      <div id='left' className='px-12 flex items-center justify-center'>
        <div id='menu-bar' className='w-20 bg-slate-700/30 backdrop-blur-md rounded-full flex flex-col items-center p-2'>
          <div className='w-16 h-16 my-1 rounded-full bg-white/70'></div>
          <div className='w-16 h-16 my-1 rounded-full bg-white/20'></div>
          <div className='w-16 h-16 my-1 rounded-full bg-white/20'></div>
        </div>
      </div>

      <div id='right' className='flex-1 flex items-center justify-center'>
        <div id='main-section' className='bg-slate-700/30 backdrop-blur-md w-7/8 h-6/8 rounded-3xl'></div>
      </div>

    </div>
  )
}

export default App
