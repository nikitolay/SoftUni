function pieceOfPie(pieFlavorsArray, targetFlavor1, targetFlavor2) {
  let result = [];
  let indexOfTarget1 = pieFlavorsArray.indexOf(`${targetFlavor1}`);
  let indexOfTarget2 = pieFlavorsArray.indexOf(`${targetFlavor2}`);
  result = pieFlavorsArray.slice(indexOfTarget1, indexOfTarget2 + 1);
  return result;
}
console.log(
  pieceOfPie(
    [
      "Apple Crisp",
      "Mississippi Mud Pie",
      "Pot Pie",
      "Steak and Cheese Pie",
      "Butter Chicken Pie",
      "Smoked Fish Pie",
    ],
    "Pot Pie",
    "Smoked Fish Pie"
  )
);
