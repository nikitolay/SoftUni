function sortArray(array) {
  array.sort((a, b) => a.length - b.length || a.localeCompare(b));
  console.log(array.join("\n"));
}
sortArray(["Isacc", "Theodor", "Jack", "Harrison", "George"]);
