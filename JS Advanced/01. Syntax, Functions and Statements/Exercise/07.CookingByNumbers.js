function cookingByNumbers(
  number,
  command1,
  command2,
  command3,
  command4,
  command5
) {
  let arr = [command1, command2, command3, command4, command5];
  let result = Number(number);
  for (let i = 0; i < arr.length; i++) {
    let currentCommand = arr[i];
    if (currentCommand == "chop") {
      result /= 2;
    } else if (currentCommand == "dice") {
      result = Math.sqrt(result);
    } else if (currentCommand == "spice") {
      result += 1;
    } else if (currentCommand == "bake") {
      result *= 3;
    } else if (currentCommand == "fillet") {
      result *= 0.8;
    }
    console.log(result);
  }
}
cookingByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet')