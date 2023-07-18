function constructionCrew(worker) {
  if (worker.dizziness) {
    worker.levelOfhydrated += 0.1 * worker.weight * worker.experience;
    worker.dizziness = false;
  }

  return worker;
}
