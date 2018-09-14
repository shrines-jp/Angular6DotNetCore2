import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html'
})
export class GameComponent {
  public games: Game[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Game[]>(baseUrl + 'api/Game').subscribe((result : Game[]) => {
      console.log(result);
      this.games = result;
    }, error => console.error(error));
  }
}

interface Game {
  id: string;
  name: string;
  developer: string;
  publisher: string;
  platforms: string[];
}
