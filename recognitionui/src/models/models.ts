export default interface Product {
    id?: number,
    name : string,
    imageUri : string,
    description? : string,
    price : number
}

export type Recognition = {
    header : string,
    imageUri : string,
    recognizedName : string,
    recognizedByName: string
}

