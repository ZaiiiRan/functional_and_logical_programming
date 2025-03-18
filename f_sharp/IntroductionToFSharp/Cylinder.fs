module Cylinder
open System

let circleArea r = (Math.PI*r*r)
let cylinderVolume r h = (circleArea r) * h

let multiplyAreaH area h = area * h
let cylinderVolumeSuperPosition = (circleArea >> multiplyAreaH)