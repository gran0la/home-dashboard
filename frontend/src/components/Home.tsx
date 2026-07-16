import useNow from "../hooks/useDate";
import { useEffect, useState } from "react";

function Home() {
  const now = useNow();

  const [weatherData, setWeatherData] = useState<any>(null);

  const weatherURL =
    "https://api.open-meteo.com/v1/forecast?latitude=57.1437&longitude=-2.0981&hourly=temperature_2m,weather_code,relative_humidity_2m,wind_speed_10m,visibility,precipitation,precipitation_probability,rain,showers,snowfall&current=temperature_2m,rain,wind_speed_10m,relative_humidity_2m,is_day,snowfall,showers,apparent_temperature,weather_code";

  useEffect(() => {
    fetch(weatherURL)
      .then((res) => res.json())
      .then((data) => setWeatherData(data));
  }, []);

  const currentHour = now.getHours().toString().padStart(2, "0");

  const startIndex =
    weatherData?.hourly?.time.findIndex(
      (time: string) => time.slice(11, 13) === currentHour
    ) ?? 0;

  return (
    <div id="Home" className="flex w-full">
      <div id="left" className="w-2/3 h-full p-5 grid grid-cols-4 grid-rows-8 gap-5">
        <div className="col-start-1 col-span-3 row-span-2 bg-slate-200/20 rounded-lg flex gap-5">
          {weatherData?.hourly?.time
            .slice(startIndex)
            .filter((_: any, index: number) => index % 3 === 0)
            .slice(0, 6)
            .map((time: string, index: number) => (
              <div key={time} className="p-2 rounded-md bg-slate-950/20">
                <p>{time.slice(11, 16)}</p>
                <p>
                  {
                    weatherData.hourly.visibility[
                    startIndex + index * 3
                    ]
                  }
                </p>
                <p>
                  {
                    weatherData.hourly.temperature_2m[
                    startIndex + index * 3
                    ]
                  }
                  °C
                </p>
              </div>
            ))}
        </div>

        <div className="col-start-4 col-span-1 row-span-2 bg-slate-200/40 rounded-lg"></div>
        <div className="col-start-1 col-span-1 row-start-3 row-span-2 bg-slate-200/20 rounded-lg"></div>
        <div className="col-start-2 col-span-2 row-start-3 row-span-2 bg-slate-200/40 rounded-lg"></div>
        <div className="col-start-4 col-span-1 row-start-3 row-span-2 bg-slate-200/20 rounded-lg"></div>
        <div className="col-start-1 col-span-4 row-start-5 row-span-4 bg-slate-200/20 rounded-lg"></div>
      </div>

      <div id="right" className="flex-1 bg-slate-950/30 p-5">
        <h1
          id="time"
          className="text-white text-center font-medium mb-12 text-2xl"
        >
          {now.toLocaleTimeString("en-GB", {
            hour: "2-digit",
            minute: "2-digit",
          })}
        </h1>

        <div id="temp" className="flex flex-col items-center justify-center mb-12">
          <h1 className="text-white font-medium w-full text-left">
            Thermostat
          </h1>

          <div className="w-48 h-48 rounded-full border-8 border-slate-200/80 flex items-center justify-center">
            <p className="text-white font-medium text-3xl">12°C</p>
          </div>
        </div>

        <div className="flex w-full gap-5 justify-between">
          <div className="flex-1 h-20 rounded-lg bg-slate-200/20"></div>
          <div className="flex-1 h-20 rounded-lg bg-slate-200/20"></div>
          <div className="flex-1 h-20 rounded-lg bg-slate-200/20"></div>
          <div className="flex-1 h-20 rounded-lg bg-slate-200/20"></div>
        </div>
      </div>
    </div>
  );
}

export default Home;
