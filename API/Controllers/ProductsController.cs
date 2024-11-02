using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ProductsController(/*IProductRepository repo*/ IGenericRepository<Product> repo) : ControllerBase
{
  /*  private readonly StoreContext context;

    public ProductsController(StoreContext context)
    {
        this.context = context;
    }
    */

/*
 [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
       return Ok(await repo.GetProductsAsync());
    }
    */
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(string? brand, string? type, string? sort)
    {
       // return await context.Products.ToListAsync();
       //return Ok(await repo.GetProductsAsync(brand, type, sort));

       var spec = new ProductSpecification(brand, type, sort);

       var products = await repo.ListAsync(spec);


       return Ok(products);
        //return Ok(await repo.ListAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        //var product = await context.Products.FindAsync(id);



       // var product = await repo.GetProductByIdAsync(id);

        var product = await repo.GetByIdAsync(id);

        if(product == null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
       // context.Products.Add(product);

       // await context.SaveChangesAsync();



       //repo.AddProduct(product);


       repo.Add(product);
       if(await /*repo.SaveChangesAsync()*/ repo.SaveAllAsync())
       {
           return CreatedAtAction("GetProduct", new {id = product.Id}, product);
       }

       return BadRequest("Problem creating product");

        //return product;
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateProduct(int id, Product product)
    {
        if(product.Id != id || !ProductExists(id))
        {
            return BadRequest("Cannot update this product");
        }

        //context.Entry(product).State = EntityState.Modified;

        //await context.SaveChangesAsync();

      
      
       // repo.UpdateProduct(product);

       repo.Update(product);

        if(/*await repo.SaveChangesAsync()*/ await repo.SaveAllAsync())
        {
            return NoContent();
        }


        //return NoContent();
        return BadRequest("Problem updating the product");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        //var product = await context.Products.FindAsync(id);

        
        //var product = await repo.GetProductByIdAsync(id);

        var product = await repo.GetByIdAsync(id);
        if(product == null)
        {
            return NotFound();
        }

        //repo.DeleteProduct(product);
        repo.Remove(product);

        if(/*await repo.SaveChangesAsync()*/ await repo.SaveAllAsync())
        {
            return NoContent();
        }

       // context.Products.Remove(product);

       // await context.SaveChangesAsync();

        return NoContent();
    }
/*
    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
    {
        return Ok(await repo.GetBrandAsync());
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
    {
        return Ok(await repo.GetTypesAsync());
    }
*/


    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
    {
        var spec = new BrandListSpecification();

        return Ok(await repo.ListAsync(spec));
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
    {
        var spec = new TypeListSpecificaton();

        return Ok(await repo.ListAsync(spec));
    }
   private bool ProductExists(int id)
{
    //return context.Products.Any(x => x.Id == id);
    
    
    //return repo.ProductExists(id);

     return repo.Exists(id);
}
}
