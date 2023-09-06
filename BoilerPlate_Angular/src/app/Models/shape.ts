export interface Shape {
    id: string;
    formType: string;
    positionX: number;
    positionY: number;
    width: number;
    height: number;
    text: string;
    order: number;
}

export interface ShapesList {
    shapes: Shape[];
}
