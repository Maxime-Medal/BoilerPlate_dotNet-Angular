import { Component } from '@angular/core';
import { ShapesService } from '../Services/shapes.service';
import { Shape } from '../Models/shape';

@Component({
  selector: 'app-exercise-page',
  templateUrl: './exercise-page.component.html',
  styleUrls: ['./exercise-page.component.css']
})
export class ExercisePageComponent {
  public shapes: Shape[] = [];

  constructor(
    private shapesService: ShapesService
  ) {
    this.getShapes();
  }

  public getShapes(): void {
    this.shapesService.getShapes().subscribe(s => {
      this.shapes = s
      this.CanvasInit();
    });
  }

  private CanvasInit() {
    if (this.shapes.length > 0) {
      const canvas = document.getElementById("canvas") as HTMLCanvasElement;
      const ctx = canvas.getContext("2d");
      if (ctx) {
        this.draw(ctx);
      }
    }
  }

  draw(ctx: CanvasRenderingContext2D) {
    this.shapes
      .forEach(s => {
        ctx.globalCompositeOperation = 'xor';
        switch (s.formType) {
          case "Rectangle":
            ctx.lineWidth = 1;
            ctx.strokeRect(s.positionX, s.positionY, s.width, s.height);
            break;
          case "Circle":
            ctx.beginPath();
            ctx.lineWidth = 1;
            ctx.arc(s.positionX, s.positionY, s.width / 2, 0, 2 * Math.PI, false);
            ctx.stroke();
            break;
          default:
            ctx.font = "40px Arial";
            ctx.textAlign = "center";
            ctx.textBaseline = "middle"
            ctx.fillText(s.text, s.positionX / 2, s.positionY);
            break;
        }
      });
  }
}
