function addAndRemoveElements(array) {
  let number = 1;
  let resultArray = [];
  for (let i = 0; i < array.length; i++) {
    if (array[i] === "add") {
      resultArray.push(number);
    } else if (array[i] === "remove") {
      resultArray.pop(number);
    }
    number++;
  }
  if (resultArray.length > 0) {
    console.log(resultArray.join("\n"));
  } else {
    console.log("Empty");
  }
}
addAndRemoveElements(["add", "add", "add", "add"]);
