import useNow from "../hooks/useDate";

function Home() {
  const now = useNow();

  return (
    <div id="Home" className="flex w-full">
      <div id='left' className='w-2/3 h-full p-5 grid grid-cols-4 grid-rows-8 gap-5'>
        <div className="col-start-1 col-span-2 row-span-2 bg-slate-200/20 rounded-lg"></div>
        <div className="col-start-3 col-span-2 bg-slate-200/40 rounded-lg"></div>
        <div className="col-start-3 col-span-2 row-start-2 bg-slate-200/40 rounded-lg"></div>
        <div className="col-start-1 col-span-1 row-start-3 row-span-2 bg-slate-200/20 rounded-lg"></div>
        <div className="col-start-2 col-span-2 row-start-3 row-span-2 bg-slate-200/40 rounded-lg"></div>
        <div className="col-start-4 col-span-1 row-start-3 row-span-2 bg-slate-200/20 rounded-lg"></div>
        <div className="col-start-1 col-span-4 row-start-5 row-span-4 bg-slate-200/20 rounded-lg"></div>
      </div>
      <div id='right' className='flex-1 bg-slate-950/30 p-5'>
        <h1 id="time" className="text-white text-center font-medium mb-12 text-2xl">{now.toLocaleTimeString("en-GB", {
          hour: "2-digit",
          minute: "2-digit"
        })}</h1>

        <div id="temp" className="flex flex-col items-center justify-center mb-12">
          <h1 className="text-white font-medium w-full text-left">Thermostat</h1>
          <div id="circle" className="w-48 h-48 rounded-full border-8 border-slate-200/80 flex items-center justify-center">
            <p className="text-white font-medium text-3xl">12c</p>
          </div>
        </div>

        <div id='box-container' className='flex w-full gap-5 justify-between'>
          <div className='flex-1 h-20 rounded-lg bg-slate-200/20'></div>
          <div className='flex-1 h-20 rounded-lg bg-slate-200/20'></div>
          <div className='flex-1 h-20 rounded-lg bg-slate-200/20'></div>
          <div className='flex-1 h-20 rounded-lg bg-slate-200/20'></div>
        </div>
      </div>
    </div>
  )
}

export default Home;
