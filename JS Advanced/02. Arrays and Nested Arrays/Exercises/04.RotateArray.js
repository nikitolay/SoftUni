function rotateArray(array, amountOfRotation) {
  for (let i = 0; i < amountOfRotation; i++) {
    // let first = array.shift();
    let last = array.pop();
    // array.push(first);
    array.unshift(last);
  }

  console.log(array.join(" "));
}
rotateArray(["1", "2", "3", "4"], 2);
