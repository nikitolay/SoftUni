function carFactory(input) {
  let engines = {
    Small: {
      power: 90,
      volume: 1800,
    },
    Normal: {
      power: 120,
      volume: 2400,
    },
    Monster: {
      power: 200,
      volume: 3500,
    },
  };
  let engine = {};
  if (input.power <= 90) {
    engine.power = input.power;
    engine.volume = engines["Small"].volume;
  } else if (input.power <= 120) {
    engine.power = input.power;
    engine.volume = engines["Normal"].volume;
  } else if (input.power <= 200) {
    engine.power = input.power;
    engine.volume = engines["Monster"].volume;
  }
  let carriage = {
    type: input.carriage,
    color: input.color,
  };
  let result = {
    model: input.model,
    engine: engine,
    carriage: carriage,
  };
  if (input.wheelsize % 2 === 0) {
    let arr = Array(4)
      .fill()
      .map(() => input.wheelsize - 1);
    result.wheels = arr;
  } else {
    let arr = Array(4)
      .fill()
      .map(() => input.wheelsize);
    result.wheels = arr;
  }
  return result;
}
// console.log(
//   carFactory({
//     model: "VW Golf II",
//     power: 90,
//     color: "blue",
//     carriage: "hatchback",
//     wheelsize: 14,
//   })
// );
console.log(
    carFactory({ model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17 }
  )
  );
  
