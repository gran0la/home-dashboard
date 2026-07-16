import { useEffect, useState } from "react";
import type { Plant } from "../types/Plant";

function Plants() {
  const url = "http://localhost:5055/plants"
  const [plantData, setPlantData] = useState<Plant[]>([]);

  useEffect(() => {
    fetch(url)
      .then(res => res.json())
      .then(data => setPlantData(data));
  }, [])

  return (
    <div id='plant-selection' className='w-full flex gap-3'>
    </div>
  )
}

export default Plants;


// {
//   plantData.map((plant: Plant) => {
//     return (
//       <div key={plant.id} className='border-dashed border-2 bg-green-300/20 border-green-500/40 p-2 rounded-2xl flex-1'>
//         <h1>Name: {plant.name}</h1>
//         <h1>Plant ID: {plant.id}</h1>
//         <h1>MoistureThreshold: {plant.moistureThreshold}</h1>
//       </div>
//     )
//   })
// }
